
using MainApp.Models;
using System.Diagnostics;

namespace MainApp.Services;

public class UserService
{
    private List<User> _users = [];
    public ServiceResponse CreateUser(User user)
    { 
        try
        {
            if (string.IsNullOrEmpty(user.Email)) 
            
                return new ServiceResponse { Success = false, Message = "No e-mail address was provided"};
            
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            
                return new ServiceResponse { Success = false, Message = "First and last name must be provided"};
            
            if (_users.Any(x => x.Email == user.Email))
                
                return new ServiceResponse { Success = false, Message = "User with the same email address already exists" };
                    
            _users.Add(user);
            return new ServiceResponse { Success = true, Message = "User was created successfully!"};

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new ServiceResponse { Success = false, Message = ex.Message };
        }
    }
    public IEnumerable<User> GetAllUsers()
    {
        try
        {
            return _users;
        }
        catch (Exception ex ) 
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }
}
