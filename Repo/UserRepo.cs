using TechroseDemo.Repo;
using static TechroseDemo.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;

namespace TechroseDemo
{
    public partial class BaseRepo : IRepo
    {
        #region UserLogin
        public UserModelLoginResult UserLogin(UserModelLoginArgs args)
        {
            UserModelLoginResult result = new();

            #region ControlsOfCredentials
            if (args.UserName.Equals(null) || args.UserName.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToString();

                return result;
            }

            if (args.Password.Equals(null) || args.Password.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToString();

                return result;
            }
            #endregion

            #region ControlDatabaseForUser
            UserModel? userResult = DatabaseContext.Users.SingleOrDefault(
                u => u.Email == args.UserName || u.PhoneNumber == args.UserName    
            );

            if (userResult == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0401.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0401.ToDescription();

                return result;
            }
            #endregion

            #region PasswordChecking
            bool passwordCheck = PasswordHashing.PasswordHashCheck(new PasswordHashModel() { HashedPassword = userResult.HashedPassword, PasswordToHash = args.Password, Salt = userResult.SaltedPassword });

            if (!passwordCheck)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0400.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0400.ToDescription();

                return result;
            }
            #endregion

            #region Token
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Constants.tConstant_SecretKey));

            SigningCredentials credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, string.Concat(userResult.FirstName, " ", userResult.LastName)),
                new Claim(ClaimTypes.Email, userResult.Email)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "*azurewebsites.net",
                audience: "*azurewebsites.net",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: credentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            #endregion

            #region PreparingResponse
            result.FullName = string.Concat(userResult.FirstName, " ", userResult.LastName);
            result.Id = userResult.Id;
            result.Token = tokenString;
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";
            #endregion

            return result;
        }
        #endregion

        #region UserCreate
        public UserModelCreateResult UserCreate(UserModelCreateArgs args)
        {
            UserModelCreateResult result = new();

            #region ControlsOfCredentials
            if (args.FirstName.Equals(null) || args.FirstName.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.LastName.Equals(null) || args.LastName.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.PhoneNumber.Equals(null) || args.PhoneNumber.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.Email.Equals(null) || args.Email.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.Password.Equals(null) || args.Password.Trim().Equals("") || args.Password.Length < 6)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.Weight.Equals(null) || args.Weight.Equals(double.MinValue))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.BirthDate.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }
            #endregion

            #region ControlDatabaseForUserExist
            UserModel? userResult = DatabaseContext.Users.SingleOrDefault(
                u => u.Email == args.Email || u.PhoneNumber == args.PhoneNumber
            );

            if (userResult != null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0404.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0404.ToDescription();

                return result;
            }
            #endregion

            #region PasswordHashing
            PasswordHashModel hashedPassword = PasswordHashing.PasswordHash(args.Password);
            #endregion

            #region NewUserCreated
            UserModel user = new()
            {
                FirstName = args.FirstName,
                LastName = args.LastName,
                BirthDate = args.BirthDate,
                HashedPassword = hashedPassword.HashedPassword,
                SaltedPassword = hashedPassword.Salt,
                Email = args.Email,
                PhoneNumber = args.PhoneNumber,
                Weight = args.Weight,
                TotalDoseValue = args.Weight * 0.55,
                BloodSugarValue = args.BloodSugarValue
            };
            #endregion

            #region AddUserToDatabase
            DatabaseContext.Users.Add(user);
            DatabaseContext.SaveChanges();
            #endregion

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }

        #region UserDelete
        public UserModelDeleteResult UserDelete(UserModelDeleteArgs args)
        {
            UserModelDeleteResult result = new();

            #region CheckCredential
            if (args.Id.Equals(null) || args.Id.Equals(int.MinValue))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }
            #endregion

            #region FindUserByUserId
            UserModel? userResult = DatabaseContext.Users.SingleOrDefault(
                u => u.Id == args.Id    
            );

            if (userResult == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0401.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0401.ToDescription();

                return result;
            }
            #endregion

            #region RemoveFromDatabase
            DatabaseContext.Users.Remove(userResult);
            DatabaseContext.SaveChanges();
            #endregion

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion

        #region UserList
        public UserModelListResult UserList(UserModelListArgs args)
        {
            UserModelListResult result = new();

            #region CheckCredential
            if (args.Limit.Equals(int.MinValue))
            {
                args.Limit = 10;
            }

            if (args.Offset.Equals(int.MinValue))
            {
                args.Offset = 0;
            }
            #endregion

            #region TakeListFromDatabase
            IQueryable<UserModel> query = DatabaseContext.Users
                .OrderBy(u => u.Id)
                .Skip(args.Offset)
                .Take(args.Limit);
            #endregion

            #region CheckList
            if (query.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0899.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0899.ToDescription();

                return result;
            }
            #endregion

            #region PreparingToResult
            result.Users = [.. query];
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";
            #endregion

            return result;
        }
        #endregion
        #endregion
    }
}
