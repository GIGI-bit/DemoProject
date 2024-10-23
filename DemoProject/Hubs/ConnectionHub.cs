using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.Entities.Models;

namespace DemoProject.Hubs
{
    //public class ConnectionHub:Hub
    //{

    //    private readonly UserManager<User> _userManager;
    //    private readonly IHttpContextAccessor _contextAccessor;
    //    private readonly IUserService _userService;

    //    public ConnectionHub(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IUserService userService)
    //    {
    //        _userManager = userManager;
    //        _contextAccessor = contextAccessor;
    //        _userService = userService;
    //    }

    //    public override async Task OnConnectedAsync()
    //    {
    //        var httpContext=_contextAccessor.HttpContext;
    //        var user = await _userManager.GetUserAsync(httpContext.User);
    //        if (user != null)
    //        {
    //            user.IsOnline = true;
    //            await _userService.Update(user);
    //            await _userManager.UpdateAsync(user);

    //        }
    //        await Clients.All.SendAsync("ReceiveConnectInfo", $"{user?.UserName} has connected");
    //    }

    //    public override async Task OnDisconnectedAsync(Exception? exception)
    //    {
    //        var httpContext = _contextAccessor.HttpContext;
    //        var user = await _userManager.GetUserAsync(httpContext.User);
    //        if (user != null)
    //        {
    //            user.IsOnline = false;
    //            await _userService.Update(user);
    //            await _userManager.UpdateAsync(user);

    //        }
    //        await Clients.Others.SendAsync("DisconnectInfo", $"{user.UserName} has disconnected");

    //    }
    //}


}
