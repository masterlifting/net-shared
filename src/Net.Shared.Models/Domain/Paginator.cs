﻿namespace Net.Shared.Models.Domain;

public class Paginator<T>
{
    private int _page;
    private int _limit;

    public Paginator(int page, int limit)
    {
        _page = page;
        _limit = limit;
    }
}