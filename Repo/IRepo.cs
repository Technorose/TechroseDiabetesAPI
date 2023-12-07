namespace TechroseDemo
{
    public interface IRepo
    {
        UserModelLoginResult UserLogin(UserModelLoginArgs args);

        UserModelCreateResult UserCreate(UserModelCreateArgs args);
    }
}
