using second_exersice;
using Service;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace ServiceTest;

public class ItemServiceTest
{
    UserService service = new UserService();
    [Fact]
    public void Register_ShouldAddUser_WhenUsernameIsUnique()
    {
       
        User user = new User ("user1", "pass", "user1@example.com",false );
        Boolean result = service.Register(user);

        Assert.True(result);
    }
    [Fact]
    public void Register_ShouldFail_WhenUsernameAlreadyExists()
    {
        UserService service2 = new UserService();
        User user1 = new User ( "user1", "pass", "user1@example.com" ,false);
        User user2 = new User ( "user1", "pass2", "user2@example.com",false); 
        service2.Register (user1);
        Boolean result = service2.Register(user2);
        Assert.False(result);
    }

    [Fact]
    public void loginTest()
    {
        UserService service = new UserService();
        User user1 = new User("user1", "pass", "user1@example.com", false);
        service.Register(user1);
        
        User result=service.Login("user1", "pass");
        
        Assert.Equals(user1, result);
    }
    
    [Fact]
    public void UpdateUserExists()
    {
        UserService service = new UserService();
        User user = new User ( "user1", "pass", "old@example.com" ,false);
        service.Register(user);

        Boolean result = service.UpdateUser("user1", "new@example.com");

        Assert.True(result);
    }

    [Fact]
    public void UpdateUserDoesNotExist()
    {
        UserService service = new UserService();

        Boolean result = service.UpdateUser("nonexistent", "new@example.com");

        Assert.False(result);
    }
    
}