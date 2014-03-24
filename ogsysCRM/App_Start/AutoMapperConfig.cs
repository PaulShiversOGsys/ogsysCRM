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



                    c.Address = new Address()
                    {
                        Street = v.Street,
                        City = v.City,
                        State = v.State,
                        PostalCode = v.PostalCode
                    };
                });

            Mapper.CreateMap<EditCustomerViewModel, Customer>()
                .AfterMap((EditCustomerViewModel v, Customer c) =>
                {
                    if (v.UseEmailForGravatar)
                    {
                        c.AvatarUrl = GravatarUtil.GetGravatarImgUrl(v.EmailAddress);
                    }

                    c.Address = new Address()
                    {
                        Street = v.Street,
                        City = v.City,
                        State = v.State,
                        PostalCode = v.PostalCode,
                        Id = v.AddressId
                    };
                });

            Mapper.CreateMap<Customer, EditCustomerViewModel>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address.PostalCode))
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Address.Id))
                .AfterMap((Customer c, EditCustomerViewModel v) =>
                {
                    v.UseEmailForGravatar = !String.IsNullOrWhiteSpace(c.AvatarUrl);
                }
            );

            Mapper.CreateMap<Customer, DetailsCustomerViewModel>()
                .AfterMap((Customer c, DetailsCustomerViewModel v) =>
                {
                    v.Address = String.Join(System.Environment.NewLine, new string[] { 
                        c.Address.Street,
                        c.Address.City,
                        c.Address.State,
                        c.Address.PostalCode
                    });
                }
            );

            Mapper.CreateMap<Note, NoteViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .AfterMap((Note n, NoteViewModel v) =>
                {
                    if (n.Customer != null)
                        v.CustomerName = String.Format("{0} {1}", n.Customer.FirstName, n.Customer.LastName);
                    else
                        v.CustomerName = "";
                }
            );

            Mapper.CreateMap<NoteViewModel, Note>();
        }
    }
}