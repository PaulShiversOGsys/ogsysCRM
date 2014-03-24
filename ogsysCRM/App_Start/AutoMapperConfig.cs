using AutoMapper;
using ogsysCRM.Models;
using ogsysCRM.Utils;
using ogsysCRM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogsysCRM.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<CreateCustomerViewModel, Customer>()
                .AfterMap((CreateCustomerViewModel v, Customer c) =>
                {
                    if (v.UseEmailForGravatar)
                    {
                        c.AvatarUrl = GravatarUtil.GetGravatarImgUrl(v.EmailAddress);
                    }
                });

            Mapper.CreateMap<EditCustomerViewModel, Customer>()
                .AfterMap((EditCustomerViewModel v, Customer c) =>
                {
                    if (v.UseEmailForGravatar)
                    {
                        c.AvatarUrl = GravatarUtil.GetGravatarImgUrl(v.EmailAddress);
                    }
                });

            Mapper.CreateMap<Customer, EditCustomerViewModel>()
                .AfterMap((Customer c, EditCustomerViewModel v) =>
            {
                v.UseEmailForGravatar = !String.IsNullOrWhiteSpace(c.AvatarUrl);
            });
        }
    }
}