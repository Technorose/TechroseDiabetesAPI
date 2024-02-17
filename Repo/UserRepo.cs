using TechroseDemo.Repo;
using static TechroseDemo.Enums;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.Password.Equals(null) || args.Password.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

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
            TokenCreateModelArgs tokenCreateModelArgs = new();

            Claim[] claims = new[]
            {
                new Claim(CoreStaticVars.ClaimTypeFullName, string.Concat(userResult.FirstName, " ", userResult.LastName)),
                new Claim(CoreStaticVars.ClaimTypeEmail, userResult.Email)
            };

            tokenCreateModelArgs.Claims = claims;

            TokenCreateModelResult token = TokenUtility.CreateToken(tokenCreateModelArgs);
            #endregion

            #region PreparingResponse
            result.User = Mapper.Map<UserModelDto>(userResult);
            result.Token = token.Token;
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

            if(!Validate.ValidateEmail(args.Email))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0406.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0406.ToDescription();

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
                TotalDoseValue = args.Weight * CoreStaticVars.TotalDoseCoefficient,
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
                args.Limit = CoreStaticVars.DefaultLimitValue;
            }

            if (args.Offset.Equals(int.MinValue))
            {
                args.Offset = CoreStaticVars.DefaultOffsetValue;
            }
            #endregion

            #region TakeListFromDatabase
            List<UserModel> query = DatabaseContext.Users
                .OrderBy(u => u.Id)
                .Skip(args.Offset)
                .Take(args.Limit)
                .ToList();
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
            result.Users = Mapper.Map<List<UserModelDto>>(query);
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";
            #endregion

            return result;
        }
        #endregion
        #endregion

        #region UserUpdatePassword
        public UserModelUpdatePasswordResult UserUpdatePassword(UserModelUpdatePasswordArgs args, HeaderModelArgs headers)
        {
            UserModelUpdatePasswordResult result = new();

            if(headers.Authorization.Equals(null) || headers.Authorization.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.OldPassword.Equals(null) || args.OldPassword.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.NewPassword.Equals(null) || args.NewPassword.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.ConfirmPassword.Equals(null) || args.ConfirmPassword.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (!args.NewPassword.Equals(args.ConfirmPassword) || args.NewPassword.Equals(args.OldPassword))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            TokenDecodeModelArgs tokenDecodeModelArgs = new TokenDecodeModelArgs();
            tokenDecodeModelArgs.AuthorizationToken = headers.Authorization;

            TokenDecodeModelResult tokenDecodeModelResult = TokenUtility.DecodeToken(tokenDecodeModelArgs);
            
            string? email = tokenDecodeModelResult.Claims.GetValueOrDefault(CoreStaticVars.ClaimTypeEmail);

            UserModel? user = DatabaseContext.Users.SingleOrDefault(
                u => u.Email == email
            );

            if(user == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0401.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0401.ToDescription();

                return result;
            }

            PasswordHashModel passwordHashModel = new PasswordHashModel();

            passwordHashModel.PasswordToHash = args.OldPassword;
            passwordHashModel.HashedPassword = user.HashedPassword;
            passwordHashModel.Salt = user.SaltedPassword;

            bool ok = PasswordHashing.PasswordHashCheck(passwordHashModel);
            if(!ok)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0400.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0400.ToDescription();

                return result;
            }

            PasswordHashModel passwordHashToModel = PasswordHashing.PasswordHash(args.NewPassword);

            user.HashedPassword = passwordHashToModel.HashedPassword;
            user.SaltedPassword = passwordHashToModel.Salt;

            DatabaseContext.Users.Update(user);
            DatabaseContext.SaveChanges();

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion

        #region UserModelDetails
        public UserModelDetailsResult UserDetails(UserModelDetailsArgs args)
        {
            UserModelDetailsResult result = new();

            if (args.Id.Equals(null) || args.Id.Equals(int.MinValue))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            UserModel? user = DatabaseContext.Users.FirstOrDefault(user => user.Id == args.Id);

            if (user == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0402.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0402.ToDescription();
                return result;
            }

            result.User = Mapper.Map<UserModelDto>(user); 
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion

        #region UserUploadProfileImage
        public async Task<UserModelUploadProfileImageResult> UserUploadProfileImage(UserModelUploadProfileImageArgs args, HeaderModelArgs headerArgs)
        {
            UserModelUploadProfileImageResult result = new();

            if (headerArgs.Authorization.Equals(null) || headerArgs.Authorization.Trim().Equals(""))  
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.Image == null || args.Image.Length.Equals(0))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }
            
            string[] postFix = args.Image.FileName.Split(".");

            string extension = postFix[postFix.Length - 1];

            bool ok = CoreStaticVars.ImageExtentions.Contains(extension.ToLower());

            if (!ok)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0403.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0403.ToDescription();

                return result;
            }

            TokenDecodeModelArgs tokenDecodeModelArgs = new TokenDecodeModelArgs();
            tokenDecodeModelArgs.AuthorizationToken = headerArgs.Authorization;

            TokenDecodeModelResult tokenDecodeModelResult = TokenUtility.DecodeToken(tokenDecodeModelArgs);

            string? email = tokenDecodeModelResult.Claims.GetValueOrDefault(CoreStaticVars.ClaimTypeEmail);

            UserModel? user = DatabaseContext.Users.SingleOrDefault(
                u => u.Email == email
            );

            if(user == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0401.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0401.ToDescription();

                return result;
            }

            string refExtension = String.Concat(".", extension);
            string fileName = String.Concat(String.Concat(user.FirstName.Trim().ToLower(), "_"), user.LastName.ToLower());

            string imageName = String.Concat(fileName, refExtension);
            string userImage = String.Concat(CoreStaticVars.ProfileImageFolderName, imageName);

            bool status = await googleCloudStorage.UploadImage(new UploadImageArgs()
            {
                ImageName = userImage,
                FormFile = args.Image,
                ImageExists = (user.Image == null || user.Image == "") ? false : true
            });

            if(!status)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0405.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0405.ToDescription();

                return result;
            }

            user.Image = userImage;

            DatabaseContext.Users.Update(user);
            await DatabaseContext.SaveChangesAsync();

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion


        #region UserGetMealsValues
        
        public UserModelTakeMealsValuesByDateResult UserGetMealsValues(UserModelTakeMealsValuesByDateArgs args, HeaderModelArgs headerArgs)
        {
            UserModelTakeMealsValuesByDateResult result = new();

            if(args.Date.Equals(null))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if(headerArgs.Authorization.Equals(null) || headerArgs.Authorization.Trim().Equals("")) 
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            TokenDecodeModelArgs tokenDecodeModelArgs = new();
            tokenDecodeModelArgs.AuthorizationToken = headerArgs.Authorization;

            TokenDecodeModelResult tokenDecodeModelResult = TokenUtility.DecodeToken(tokenDecodeModelArgs);

            string? email = tokenDecodeModelResult.Claims.GetValueOrDefault(CoreStaticVars.ClaimTypeEmail);

            UserModel? user = DatabaseContext.Users.SingleOrDefault(
                u => u.Email == email
            );

            if (user == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0401.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0401.ToDescription();

                return result;
            }

           
            UserModelTakeMealsValuesByDateResult? calculatedResult = DatabaseContext.Meals
                .Where(m => m.UserId == user.Id && m.MealTime.Date == args.Date.Date)
                .GroupBy(gm => gm.UserId)
                .Select(group => new UserModelTakeMealsValuesByDateResult
                {
                    TotalCalories = group.Sum(row => row.TotalCalorie),
                    TotalSugar = group.Sum(row => row.TotalSugar),
                    TotalCarbohydrate = group.Sum(row => row.TotalCarbohydrate),
                    BloodSugar = group.Sum(row => row.BloodSugar)
                })
                .FirstOrDefault();

            if(calculatedResult == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0703.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0703.ToDescription();

                return result;
            }
                
            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            result.TotalSugar = calculatedResult.TotalSugar;
            result.TotalCalories = calculatedResult.TotalCalories;
            result.TotalCarbohydrate = calculatedResult.TotalCarbohydrate;
            result.BloodSugar = calculatedResult.BloodSugar;

            return result;
        }
        #endregion

        #region UserUpdates
        public UserModelUpdateResult UserUpdate(UserModelUpdateArgs args, HeaderModelArgs headerArgs)
        {
            UserModelUpdateResult result = new();

            if(args.FirstName.Equals(null) || args.FirstName.Equals(string.Empty))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.LastName.Equals(null) || args.LastName.Equals(string.Empty))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.Email.Equals(null) || args.Email.Equals(string.Empty))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.PhoneNumber.Equals(null) || args.PhoneNumber.Equals(string.Empty))
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

            if (args.BloodSugarValue.Equals(null) || args.BloodSugarValue.Equals(double.MinValue))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (args.BirthDate.Equals(null) || args.BirthDate.Equals(default(DateTime)))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }

            if (headerArgs.Authorization.Equals(null) || headerArgs.Authorization.Trim().Equals(""))
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0100.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0100.ToDescription();

                return result;
            }
           
            TokenDecodeModelArgs tokenDecodeModelArgs = new();
            tokenDecodeModelArgs.AuthorizationToken = headerArgs.Authorization;

            TokenDecodeModelResult tokenDecodeModelResult = TokenUtility.DecodeToken(tokenDecodeModelArgs);

            string? email = tokenDecodeModelResult.Claims.GetValueOrDefault(CoreStaticVars.ClaimTypeEmail);  

            UserModel? user = DatabaseContext.Users.SingleOrDefault(
                u => u.Email == email
            );

            if (user == null)
            {
                result.Result.Success = false;
                result.Result.ErrorCode = EnumErrorCodes.ERRORx0401.ToString();
                result.Result.ErrorDescription = EnumErrorCodes.ERRORx0401.ToDescription();

                return result;
            }

            user.FirstName = args.FirstName;
            user.LastName = args.LastName;
            user.Email = args.Email;
            user.PhoneNumber = args.PhoneNumber;
            user.BirthDate = args.BirthDate;
            user.Weight = args.Weight;
            user.BloodSugarValue = args.BloodSugarValue;

            DatabaseContext.Users.Update(user);
            DatabaseContext.SaveChanges();

            result.User = Mapper.Map<UserModelDto>(user);    

            result.Result.Success = true;
            result.Result.ErrorCode = "";
            result.Result.ErrorDescription = "";

            return result;
        }
        #endregion
    }
}
