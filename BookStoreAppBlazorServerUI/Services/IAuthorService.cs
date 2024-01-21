﻿using BookStoreAppBlazorServerUI.Services.Base;

namespace BookStoreAppBlazorServerUI.Services
{
    internal interface IAuthorService
    {
        Task<Response<List<AuthorReadOnlyDto>>> GetAuthors();
    }
}