//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using UniPlatform.DB;

//namespace UniPlatform.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TestController : ControllerBase
//    {
//        private readonly PlatformDbContext _context;
//        public TestController(PlatformDbContext context)
//        {
//            _context = context;
//        }
//        [HttpGet]
//        [Authorize(Roles = "Student")]
//        public ActionResult<string> GetTest()
//        {
//            return "Zdorova";
//        }

//        [HttpPost]
//        [Authorize(Roles = "Lecturer")]
//        public

//}
