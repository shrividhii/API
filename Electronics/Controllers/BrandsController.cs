using Common.Mail;
using Common.UpdationModel;
using Common.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Electronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IEmailService _emailService;

        public BrandsController(IBrandService brandService, IEmailService emailService)
        {
            _brandService = brandService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandUpdationModel>>> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrands();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandUpdationModel>> GetBrandById(int id)
        {
            var brand = await _brandService.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult> AddBrand(BrandModel brandModel)
        {
            await _brandService.AddBrand(brandModel);
            return CreatedAtAction(nameof(GetBrandById), new { id = brandModel.BrandName }, new { message = "Brand added successfully" });
        }
        #region Updation without id
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(BrandUpdationModel brandModel)
        {
            try
            {
                await _brandService.UpdateBrand(brandModel);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Brand not found." });
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "The brand was modified or deleted since it was loaded." });
            }
        }
        #endregion

        //[HttpPut]
        //public async Task<IActionResult> UpdateBrand(BrandModel brandModel)
        //{
        //    try
        //    {
        //        await _brandService.UpdateBrand(brandModel);
        //        return NoContent();
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        return NotFound(new { message = "Brand not found." });
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return Conflict(new { message = "The brand was modified or deleted since it was loaded." });
        //    }
        //}


        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            try
            {
                 _brandService.DeleteBrand(id);
                return Ok(new { message = "Brand deleted successfully" });
            }
            catch(Exception)
            {
                return BadRequest("Brand not found");
            }

            //var mailRequest = new MailRequest
            //{
            //    ToMail = "vidhi.182023@gmail.com",
            //    Subject = "Brand Deleted",
            //    Body = $"Brand with ID '{id}' has been deleted."
            //};

            //await _emailService.SendEmail(mailRequest);
            //return Ok(new { message = "Brand deleted successfully" });
        }
    }
}
