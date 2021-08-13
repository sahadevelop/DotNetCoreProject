using System;
using System.Linq;

namespace TMIDotNetCoreFinalProject.Services
{
    public class UserServices : Object
    {
        //فراخوانی و درج اطلاعات از طریق سرویس محیا شده که فقط توسط کنترلر صدا زده میشود
        private static System.Collections.Generic.IList<Models.MyProjectClass.User> Users;
        public UserServices() : base()
        {

        }

        #region Get All --تابع بازگردانی لیست تمامی کاربران

        public System.Collections.Generic.IList<Models.MyProjectClass.User> GetAllUser()
        {
            System.Collections.Generic.IList<Models.MyProjectClass.User> userList = null;


            userList = Users.OrderByDescending(x => x.Username).ToList();


            return userList;

        }
        #endregion /Get All Method

        #region Get By Id  -- تابع بازگردانی کاربر بر اساس ای دی جدول


        public Models.MyProjectClass.User GetUserById(int? id)
        {
            Models.MyProjectClass.User user = null;


            return user = Users.FirstOrDefault(x => x.Id == id);

        }
        #endregion 

        #region Create New User  -- تابع ایجاد کابر جدید


        public Models.MyProjectClass.User CreateUser(Models.MyProjectClass.User user)
        {
      
            int incrementId = Users.Max(x => x.Id) + 1;

         var  addedUser = new Models.MyProjectClass.User
            {
                Id = incrementId,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                NationalNo = user.NationalNo,
                Email = user.Email,
            };


            Users.Add(addedUser);
            return addedUser;

        }
        #endregion

        #region Update By Id Method -- تابع بروزرسانی اطلاعات کاربر بر اساس ای دی جدول
     

        public Models.MyProjectClass.User UpdateUserById(Models.MyProjectClass.User user)
        {

            var findUser = Users.FirstOrDefault(x => x.Id == user.Id);
            if (findUser != null)
            {
   
                
            findUser.FirstName = user.FirstName;
            findUser.LastName = user.FirstName;
            findUser.NationalNo = user.NationalNo;
            findUser.Email = user.Email;
            findUser.Username = user.Username;
            findUser.Password = user.Password;

                //ذخیره تغییرات در دیتابیس
                //SaveChange();
                return findUser;
            }
            else
            {
                return user = null;
            }
         
        }
        #endregion

        #region Delete User By Id -- تابع حذف اطلاعات کاربر 
    
        public Models.MyProjectClass.User DeleteUserById(int? id)
        {

            var findUser = Users.FirstOrDefault(x => x.Id == id);
          var userList= GetAllUser();
            if (findUser != null && userList.Count>0)
            {


                userList.Remove(findUser);

                //ذخیره تغییرات در دیتابیس
                //SaveChange();
                return findUser;
            }
            else
            {
                return findUser = null;
            }

        }
        #endregion 
    }
}
