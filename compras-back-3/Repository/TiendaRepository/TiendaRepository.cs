﻿using compras_back_3.Context;
using compras_back_3.Models;
using Microsoft.EntityFrameworkCore;

namespace compras_back_3.Repository.TiendaRepository
{
    public class TiendaRepository : ITiendaRepository
    {
        private readonly ApplicationDbContext _context;

        public TiendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tienda>> GetAllTiendasAsync()
        {
            return await _context.Tiendas.ToListAsync();
        }

        public async Task<Tienda> GetTiendaByIdAsync(int id)
        {
            return await _context.Tiendas.FindAsync(id);
        }

        public async Task AddTiendaAsync(Tienda tienda)
        {
            _context.Tiendas.Add(tienda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTiendaAsync(Tienda tienda)
        {
            _context.Entry(tienda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTiendaAsync(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);
            _context.Tiendas.Remove(tienda);
            await _context.SaveChangesAsync();
        }
    }
}