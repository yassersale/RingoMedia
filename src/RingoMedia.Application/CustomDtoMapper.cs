using Abp.Application.Editions;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Localization;
using AutoMapper;
using RingoMedia.Authorization.Accounts.Dto;
using RingoMedia.Authorization.Delegation;
using RingoMedia.Authorization.Permissions.Dto;
using RingoMedia.Authorization.Roles;
using RingoMedia.Authorization.Roles.Dto;
using RingoMedia.Authorization.Users;
using RingoMedia.Authorization.Users.Delegation.Dto;
using RingoMedia.Authorization.Users.Dto;
using RingoMedia.Departments;
using RingoMedia.Departments.Dtos;
using RingoMedia.Editions;
using RingoMedia.Localization.Dto;
using RingoMedia.MultiTenancy;
using RingoMedia.MultiTenancy.Payments;
using RingoMedia.Reminders;
using RingoMedia.Reminders.Dtos;
using RingoMedia.Sessions.Dto;

namespace RingoMedia
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Reminders.Reminder
            configuration.CreateMap<CreateOrEditReminderDto, EditReminderDto>().ReverseMap();
            configuration.CreateMap<ReminderListDto, CreateOrEditReminderDto>().ReverseMap();
            configuration.CreateMap<ReminderListDto, Reminder>().ReverseMap();
            configuration.CreateMap<EditReminderDto, Reminder>().ReverseMap();
            configuration.CreateMap<Reminder, ShowReminderList>();
            configuration.CreateMap<Reminder, ReminderListDto>();
            configuration.CreateMap<Reminder, ReminderReport>();

            configuration.CreateMap<CreateOrEditReminderDto, Reminder>().ReverseMap();
            configuration.CreateMap<ReminderDto, Reminder>().ReverseMap();

            //Departments.Department
            configuration.CreateMap<CreateOrEditDepartmentDto, EditDepartmentDto>().ReverseMap();
            configuration.CreateMap<DepartmentListDto, CreateOrEditDepartmentDto>().ReverseMap();
            configuration.CreateMap<DepartmentListDto, Department>().ReverseMap();
            configuration.CreateMap<EditDepartmentDto, Department>().ReverseMap();
            configuration.CreateMap<Department, ShowDepartmentList>();
            configuration.CreateMap<Department, DepartmentListDto>();
            configuration.CreateMap<Department, DepartmentReport>();

            configuration.CreateMap<CreateOrEditDepartmentDto, Department>().ReverseMap();
            configuration.CreateMap<DepartmentDto, Department>().ReverseMap();
            //Inputs

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            //Edition

            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, SubscribableEdition>();

            //Payment

            configuration.CreateMap<SubscriptionPayment, SubscriptionPaymentInfoDto>();

            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Language
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));

            //Tenant

            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();

            //User Delegations
            configuration.CreateMap<CreateUserDelegationDto, UserDelegation>();

            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */
        }
    }
}