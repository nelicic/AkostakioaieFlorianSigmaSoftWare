namespace API.Services;

public interface IEmailValidator
{
    bool IsValid(string email);
}
