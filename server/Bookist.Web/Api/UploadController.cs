using Anet.Models;
using Bookist.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookist.Web.Api;

[ApiAuth]
[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly QiniuService _qiniuService;

    public UploadController(QiniuService qiniuService)
    {
        _qiniuService = qiniuService;
    }

    // ����HTML���ϴ���ʽ
    [HttpGet("[action]")]
    public TypedValue<string> QiniuToken()
    {
        var token = _qiniuService.GetUploadToken();
        return new TypedValue<string>() { Value = token };
    }

    [HttpPost("[action]")]
    public void Image(IFormFile file)
    {
        using var steam = file.OpenReadStream();
        _qiniuService.UploadFile(steam);
    }
}