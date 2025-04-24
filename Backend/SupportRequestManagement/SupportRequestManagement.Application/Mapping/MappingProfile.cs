using AutoMapper;
using SupportRequestManagement.Application.Features.Notification.Commands;
using SupportRequestManagement.Application.Features.Notification.Dtos;
using SupportRequestManagement.Application.Features.SupportCategory.Commands;
using SupportRequestManagement.Application.Features.SupportCategory.Dtos;
using SupportRequestManagement.Application.Features.SupportRequest.Commands;
using SupportRequestManagement.Application.Features.SupportRequest.Dtos;
using SupportRequestManagement.Application.Features.SupportRequestComment.Commands;
using SupportRequestManagement.Application.Features.SupportRequestComment.Dtos;
using SupportRequestManagement.Application.Features.SupportType.Commands;
using SupportRequestManagement.Application.Features.SupportType.Dtos;
using SupportRequestManagement.Application.Features.User.Commands;
using SupportRequestManagement.Application.Features.User.Dtos;
using SupportRequestManagement.Domain.Entities;

namespace SupportRequestManagement.Core.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();

            // SupportRequest
            CreateMap<SupportRequest, SupportRequestDto>().ReverseMap();
            CreateMap<CreateSupportRequestCommand, SupportRequest>();
            CreateMap<UpdateSupportRequestCommand, SupportRequest>();

            // SupportCategory
            CreateMap<SupportCategory, SupportCategoryDto>().ReverseMap();
            CreateMap<CreateSupportCategoryCommand, SupportCategory>();
            CreateMap<UpdateSupportCategoryCommand, SupportCategory>();

            // SupportType
            CreateMap<SupportType, SupportTypeDto>().ReverseMap();
            CreateMap<CreateSupportTypeCommand, SupportType>();
            CreateMap<UpdateSupportTypeCommand, SupportType>();

            // Notification
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<CreateNotificationCommand, Notification>();

            // SupportRequestComment
            CreateMap<SupportRequestComment, SupportRequestCommentDto>().ReverseMap();
            CreateMap<CreateSupportRequestCommentCommand, SupportRequestComment>();
        }
    }
}