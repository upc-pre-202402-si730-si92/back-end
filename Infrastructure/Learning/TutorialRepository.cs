﻿using Domain.Learning.Model.Entities;
using Domain.Learning.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Learning;

public class TutorialRepository :  ITutorialRepository
{
    private readonly AppDbContext _dbContext;
    public TutorialRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task AddAsync(Tutorial entity)
    {
        throw new NotImplementedException();
    }

    public Task<Tutorial?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Tutorial entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(Tutorial entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await _dbContext.Tutorials.ToListAsync();
        // ORM
        //Select * from Tutorial
    }
}