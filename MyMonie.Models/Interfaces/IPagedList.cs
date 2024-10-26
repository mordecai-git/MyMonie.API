// ========================================================================
// Copyright (c) Kingdom Scripts Technology Solutions. All rights reserved.
// Author: Mordecai Godwin
// Website: https://kingdomscripts.com. Email: mordecai@kingdomscripts.com
// ========================================================================

namespace MyMonie.Core.Interfaces;

public interface IPagedList
{
    int PageIndex { get; }
    int PageSize { get; }
    int TotalPages { get; }
    int TotalItems { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
}