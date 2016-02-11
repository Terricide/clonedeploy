﻿using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Models;

namespace BLL
{
    public class User
    {

        public static Models.ValidationResult AddUser(CloneDeployUser user)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                var validationResult = ValidateUser(user, true);
                if (validationResult.IsValid)
                {
                    uow.UserRepository.Insert(user);
                    validationResult.IsValid = uow.Save();
                }

                return validationResult;
            }
        }

        public static string TotalCount()
        {
            using (var uow = new DAL.UnitOfWork())
            {
                return uow.UserRepository.Count();
            }
        }

        public static int GetAdminCount()
        {
            using (var uow = new DAL.UnitOfWork())
            {
                return Convert.ToInt32(uow.UserRepository.Count(u => u.Membership == "Administrator"));
            }
        }
      
        public static bool DeleteUser(int userId)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                uow.UserRepository.Delete(userId);
                return uow.Save();
            }
        }

        public static bool IsAdmin(int userId)
        {
            var user = GetUser(userId);
            return user.Membership == "Administrator";
        }

        public static Models.CloneDeployUser GetUserByToken(string token)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                return uow.UserRepository.GetFirstOrDefault(x => x.Token == token);
            }
        }

        public static void SendLockOutEmail(int userId)
        {
            //Mail not enabled
            if (Settings.SmtpEnabled == "0") return;

            var lockedUser = GetUser(userId);
            foreach (var user in SearchUsers("").Where(x => x.NotifyLockout == 1 && !string.IsNullOrEmpty(x.Email)))
            {
                if (user.Membership != "Administrator" && user.Id != userId) continue;
                var mail = new Helpers.Mail
                {
                    MailTo = user.Email,
                    Body = lockedUser.Name + " Has Been Locked For 15 Minutes Because Of Too Many Failed Login Attempts",
                    Subject = "User Locked"
                };
                mail.Send();
            }
        }

        public static CloneDeployUser GetUser(int userId)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                return uow.UserRepository.GetById(userId);
            }
        }

        public static CloneDeployUser GetUser(string userName)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                return uow.UserRepository.GetFirstOrDefault(u => u.Name == userName);
            }
        }

        public static List<CloneDeployUser> SearchUsers(string searchString)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                return uow.UserRepository.Get(u => u.Name.Contains(searchString));
            }
        }

        public static Models.ValidationResult UpdateUser(CloneDeployUser user)
        {
            using (var uow = new DAL.UnitOfWork())
            {
                var validationResult = ValidateUser(user, false);
                if (validationResult.IsValid)
                {
                    uow.UserRepository.Update(user, user.Id);
                    validationResult.IsValid = uow.Save();
                }

                return validationResult;
            }
        }

        public static Models.ValidationResult ValidateUser(Models.CloneDeployUser user, bool isNewUser)
        {
            var validationResult = new Models.ValidationResult();

            if (string.IsNullOrEmpty(user.Name) || !user.Name.All(c => char.IsLetterOrDigit(c) || c == '_'))
            {
                validationResult.IsValid = false;
                validationResult.Message = "User Name Is Not Valid";
                return validationResult;
            }

            if (isNewUser)
            {
                if (string.IsNullOrEmpty(user.Password))
                {
                    validationResult.IsValid = false;
                    validationResult.Message = "Password Is Not Valid";
                    return validationResult;
                }

                using (var uow = new DAL.UnitOfWork())
                {
                    if (uow.UserRepository.Exists(h => h.Name == user.Name))
                    {
                        validationResult.IsValid = false;
                        validationResult.Message = "This User Already Exists";
                        return validationResult;
                    }
                }
            }
            else
            {
                using (var uow = new DAL.UnitOfWork())
                {
                    var originalUser = uow.UserRepository.GetById(user.Id);
                    if (originalUser.Name != user.Name)
                    {
                        if (uow.UserRepository.Exists(h => h.Name == user.Name))
                        {
                            validationResult.IsValid = false;
                            validationResult.Message = "This User Already Exists";
                            return validationResult;
                        }
                    }
                }
            }

            return validationResult;
        }
    }
}