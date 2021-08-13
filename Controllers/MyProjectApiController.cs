using Infrastructure;

using TMIDotNetCoreFinalProject.Services;

namespace TMIDotNetCoreFinalProject.Controllers
{
	[Microsoft.AspNetCore.Mvc.ApiController]

	public class MyProjectApiController : MyCustomeBaseController
	{

		//بدلیل اینکه استاد تصدیقی فرمودند که همه Api ها در یک کنترلر نوشته شود قابلیت ایجاد سرویس Restfull در این کنترلر فراهم نیست
		//به منظور ایجاد سرویس رست باید به ازای هر مدل Api مستقلی با verb Html ایجاد گردد که توسط نام متد فراخوانی نشود
		public MyProjectApiController() : base()
		{

		}
		#region Api های مربوط به User

		[Microsoft.AspNetCore.Mvc.HttpGet("Users/All")]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.User), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		/// <summary>
		/// بازگردانی لیست تمام کاربران
		/// </summary>
		/// <returns>Returned List Of Users</returns>
		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IList<Models.MyProjectClass.User>>> GetAll()
		{
			UserServices _userService = new UserServices();
			FluentResults.Result<System.Collections.Generic.IList<Models.MyProjectClass.User>> result = new FluentResults.Result<System.Collections.Generic.IList<Models.MyProjectClass.User>>();
			try
			{
				result.WithValue(value: _userService.GetAllUser());
				throw new System.Exception(message: "در دریافت اطلاعات از سرور خطایی پیش آمده!");
			}
			catch (System.Exception ex)
			{
				//دریافت ای پی سرور از کلاس Base
               var ip = ServerIp;
		result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}
		}


		//--------------------------------------------------------------------


		[Microsoft.AspNetCore.Mvc.HttpGet("Users/{id}")]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.User), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(string), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]
		/// <summary>
		/// تابع بازگردانی کاربر بر اساس ای دی جدول
		/// </summary>
		/// <returns>Returned Single User By Id</returns>
		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IEnumerable<Models.MyProjectClass.User>>> Get(int? id)
		{

			UserServices _userService = new UserServices();
			FluentResults.Result<Models.MyProjectClass.User> result = new FluentResults.Result<Models.MyProjectClass.User>();
			try
			{

				result.WithValue(value: _userService.GetUserById(id));
				throw new System.Exception(message: "در دریافت اطلاعات از سرور خطایی پیش آمده!");
			}
			catch (System.Exception ex)
			{
				//دریافت ای پی سرور از کلاس Base
				var ip = ServerIp;
				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}
		}

		//--------------------------------------------------------------------
		[Microsoft.AspNetCore.Mvc.HttpPost("Users/Create")]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.User), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(string), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]
		/// <summary>
		/// ایجاد کابر جدید
		/// </summary>
		/// <returns>Create New User</returns>
		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IEnumerable<Models.MyProjectClass.User>>> Create(Models.MyProjectClass.User User)
		{
			UserServices _userService = new UserServices();
			FluentResults.Result<Models.MyProjectClass.User> result = new FluentResults.Result<Models.MyProjectClass.User>();

			try
			{

				result.WithValue(value: _userService.CreateUser(User));
				throw new System.Exception(message: "ثبت مشخصات کاربر با خطا مواجه گردید!");
			}
			catch (System.Exception ex)
			{
				//دریافت ای پی سرور از کلاس Base
				var ip = ServerIp;
				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}


		}

		//--------------------------------------------------------------------

		[Microsoft.AspNetCore.Mvc.HttpPost("Users/Update")]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.User), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(string), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]
		/// <summary>
		/// تابع بروز رسانی مشخصات کاربر 
		/// </summary>
		/// <returns>Update User</returns>
		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IEnumerable<Models.MyProjectClass.User>>> Update(Models.MyProjectClass.User User)
		{
			UserServices _userService = new UserServices();
			FluentResults.Result<Models.MyProjectClass.User> result = new FluentResults.Result<Models.MyProjectClass.User>();



			try
			{

				result.WithValue(value: _userService.UpdateUserById(User));
				throw new System.Exception(message: "بروز رسانی مشخصات کاربر با خطا مواجه گردید!!");
			}
			catch (System.Exception ex)
			{
				//دریافت ای پی سرور از کلاس Base
				var ip = ServerIp;
				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}


		}

		//--------------------------------------------------------------------

		[Microsoft.AspNetCore.Mvc.HttpDelete("Users/{id}")]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.User), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(string), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]
		/// <summary>
		/// تابع حذف کاربر بر اساس ای دی جدول
		/// </summary>
		/// <returns>Single User</returns>

		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IEnumerable<Models.MyProjectClass.User>>> Delete(int? id)
		{
			UserServices _userService = new UserServices();
			FluentResults.Result<Models.MyProjectClass.User> result = new FluentResults.Result<Models.MyProjectClass.User>();

			try
			{

				result.WithValue(value: _userService.DeleteUserById(id));
				throw new System.Exception(message: "حذف اطلاعات کاربر با خطا مواجه گردید!");
			}
			catch (System.Exception ex)
			{
				//دریافت ای پی سرور از کلاس Base
				var ip = ServerIp;
				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}
		}

		#endregion
		#region Api های مربوط به Company


		[Microsoft.AspNetCore.Mvc.HttpGet("Company/All")]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.Company), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IList<Models.MyProjectClass.Company>>> GetAllCompany()
		{
			CompanyServices _CompanyService = new CompanyServices();
			FluentResults.Result<System.Collections.Generic.IList<Models.MyProjectClass.Company>> result = new FluentResults.Result<System.Collections.Generic.IList<Models.MyProjectClass.Company>>();
			try
			{
				result.WithValue(value: _CompanyService.GetAllCompanies());
				throw new System.Exception(message: "در دریافت اطلاعات از سرور خطایی پیش آمده!");
			}
			catch (System.Exception ex)
			{

				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}
		}


		//--------------------------------------------------------------------


		[Microsoft.AspNetCore.Mvc.HttpGet("Companys/{id}")]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.Company), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(string), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]

		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IEnumerable<Models.MyProjectClass.Company>>> GetCompanyById(int? id)
		{

			CompanyServices _CompanyService = new CompanyServices();
			FluentResults.Result<Models.MyProjectClass.Company> result = new FluentResults.Result<Models.MyProjectClass.Company>();
			try
			{

				result.WithValue(value: _CompanyService.GetCompanyById(id));
				throw new System.Exception(message: "در دریافت اطلاعات از سرور خطایی پیش آمده!");
			}
			catch (System.Exception ex)
			{

				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}
		}

		//--------------------------------------------------------------------
		[Microsoft.AspNetCore.Mvc.HttpPost("Companys/Create")]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.Company), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(string), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]

		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IEnumerable<Models.MyProjectClass.Company>>> Create(Models.MyProjectClass.Company Company)
		{
			CompanyServices _CompanyService = new CompanyServices();
			FluentResults.Result<Models.MyProjectClass.Company> result = new FluentResults.Result<Models.MyProjectClass.Company>();

			try
			{

				result.WithValue(value: _CompanyService.CreateCompany(Company));
				throw new System.Exception(message: "ثبت مشخصات شرکت با خطا مواجه گردید!");
			}
			catch (System.Exception ex)
			{

				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}


		}

		//--------------------------------------------------------------------

		[Microsoft.AspNetCore.Mvc.HttpPost("Companys/Update")]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.Company), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(string), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]

		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IEnumerable<Models.MyProjectClass.Company>>> Update(Models.MyProjectClass.Company Company)
		{
			CompanyServices _CompanyService = new CompanyServices();
			FluentResults.Result<Models.MyProjectClass.Company> result = new FluentResults.Result<Models.MyProjectClass.Company>();



			try
			{

				result.WithValue(value: _CompanyService.UpdateCompanyById(Company));
				throw new System.Exception(message: "بروز رسانی مشخصات شرکت با خطا مواجه گردید!!");
			}
			catch (System.Exception ex)
			{

				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}


		}

		//--------------------------------------------------------------------

		[Microsoft.AspNetCore.Mvc.HttpDelete("Companys/{id}")]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(Models.MyProjectClass.Company), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
		[Microsoft.AspNetCore.Mvc.ProducesResponseType(type: typeof(string), statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]

		public Microsoft.AspNetCore.Mvc.ActionResult<FluentResults.Result<System.Collections.Generic.IEnumerable<Models.MyProjectClass.Company>>> DeleteCompany(int? id)
		{
			CompanyServices _CompanyService = new CompanyServices();
			FluentResults.Result<Models.MyProjectClass.Company> result = new FluentResults.Result<Models.MyProjectClass.Company>();

			try
			{

				result.WithValue(value: _CompanyService.DeleteById(id));
				throw new System.Exception(message: "حذف اطلاعات شرکت با خطا مواجه گردید!");
			}
			catch (System.Exception ex)
			{

				result.WithError(errorMessage: ex.Message);
			}

			if (result.IsFailed)
			{
				return BadRequest(error: result.ToResult());
			}
			else
			{
				return Ok(value: result);
			}
		}
#endregion

	}

}


