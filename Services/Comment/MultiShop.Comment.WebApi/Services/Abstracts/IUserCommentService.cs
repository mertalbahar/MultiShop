﻿using MultiShop.Comment.WebApi.Dtos.UserCommentDtos;

namespace MultiShop.Comment.WebApi.Services.Abstracts
{
    public interface IUserCommentService
    {
        IEnumerable<ResultUserCommentDto> GetAllUserComments();
        GetByIdUserCommentDto GetUserCommentById(int id);
        void CreateUserComment(CreateUserCommentDto createUserCommentDto);
        void UpdateUserComment(UpdateUserCommentDto updateUserCommentDto);
        void DeleteUserComment(int id);
        IEnumerable<ResultUserCommentDto> GetyUserCommentByProductId(string id);
    }
}
