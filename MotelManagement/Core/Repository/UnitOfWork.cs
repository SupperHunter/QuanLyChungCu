﻿using MotelManagement.Core.IRepository;
using MotelManagement.Data.Models;

namespace MotelManagement.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MotelManagementContext _context;

        public IRoomTypeRepository roomTypeRepository { get; }
        public IUserRepository userRepository { get; }
        public IRoomRepository roomRepository { get;  }

        public IBookingRepository bookingRepository { get; }
        public IPassingRepository passingRepository { get; }


        public IContractRepository contractRepository  { get; }

        public IBillRepository billRepository { get; }

        public IImageRepository imageRepository { get; }

        public IEmployeeRepository employeeRepository { get; }

        public UnitOfWork(MotelManagementContext context)
        {
            _context = context;
            roomTypeRepository = new RoomTypeRepository(_context);
            userRepository = new UserRepository(_context);
            roomRepository = new RoomRepository(_context);
            bookingRepository = new BookingRepository(_context);
            passingRepository = new PassingRepository(_context);
            contractRepository = new ContractRepository(_context);
            billRepository = new BillRepository(_context);
            imageRepository = new ImageRepository(_context);
            employeeRepository = new EmployeeRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
            // Giải phóng vùng nhớ
            GC.SuppressFinalize(this);
        }
        public void save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
