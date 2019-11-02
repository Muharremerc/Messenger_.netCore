using Messeger.BLL.Interfaces.Services;
using Messeger.DAL.Interfaces;
using Messeger.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Messeger.BLL.Services
{
    public class MessageService : IMessageService
    {
        EF_IMessageRepository _eF_IMessageRepository;
        public MessageService(EF_IMessageRepository eF_IMessageRepository)
        {
            _eF_IMessageRepository = eF_IMessageRepository;
        }

        public int Add(Message entity)
        {
            return _eF_IMessageRepository.Add(entity);
        }

        public Task<int> AddAsync(Message entity)
        {
            return _eF_IMessageRepository.AddAsync(entity);
        }

        public ICollection<Message> All()
        {
            return _eF_IMessageRepository.All();
        }

        public ICollection<Message> All(Expression<Func<Message, bool>> expression)
        {
            return _eF_IMessageRepository.All(expression);
        }

        public async Task<List<Message>> AllAsync()
        {
            return await _eF_IMessageRepository.AllAsync();
        }

        public async Task<List<Message>> AllAsync(Expression<Func<Message, bool>> expression)
        {
            return await _eF_IMessageRepository.AllAsync(expression);
        }

        public bool Delete(Message entity)
        {
            return _eF_IMessageRepository.Delete(entity);
        }

        public bool Delete(int entityID)
        {
            return _eF_IMessageRepository.Delete(entityID);
        }

        public Task<bool> DeleteAsync(Message entity)
        {
            return _eF_IMessageRepository.DeleteAsync(entity);
        }

        public Task<bool> DeleteAsync(int entityID)
        {
            return _eF_IMessageRepository.DeleteAsync(entityID);
        }

        public Message Get(int entityID)
        {
            return _eF_IMessageRepository.Get(entityID);
        }

        public Message Get(Expression<Func<Message, bool>> expression)
        {
            return _eF_IMessageRepository.Get(expression);
        }

        public List<Message> GetAllMessageWithMemberInfo(int MemberID)
        {
            return _eF_IMessageRepository.GetAllMessageWithMemberInfo(MemberID);
        }

        public Message GetAllMessageWithMessageIDInfo(Expression<Func<Message, bool>> expression)
        {
            return _eF_IMessageRepository.GetAllMessageWithMessageIDInfo(expression);
        }

        public async Task<Message> GetAsync(int entityID)
        {
            return await _eF_IMessageRepository.GetAsync(entityID);
        }

        public async Task<Message> GetAsync(Expression<Func<Message, bool>> expression)
        {
            return await _eF_IMessageRepository.GetAsync(expression);
        }

        public Message GetMessageDetailsWithMessageID(int MessageID)
        {
            return _eF_IMessageRepository.GetMessageDetailsWithMessageID(MessageID);
        }

        public void Save()
        {

            _eF_IMessageRepository.Save();
        }

        public bool Update(Message entity)
        {
            return _eF_IMessageRepository.Update(entity);
        }

        public Task<bool> UpdateAsync(Message entity)
        {
            return _eF_IMessageRepository.UpdateAsync(entity);
        }
    
    }
}
