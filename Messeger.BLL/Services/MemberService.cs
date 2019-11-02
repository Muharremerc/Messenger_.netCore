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
    public class MemberService : IMemberService
    {
        EF_IMemberRepository _eF_IMemberRepository;
        public MemberService(EF_IMemberRepository eF_IMemberRepository)
        {
            _eF_IMemberRepository = eF_IMemberRepository;
        }

        public int Add(Member entity)
        {
            return _eF_IMemberRepository.Add(entity);            
        }

        public Task<int> AddAsync(Member entity)
        {
            return _eF_IMemberRepository.AddAsync(entity);            
        }

        public ICollection<Member> All()
        {
            return _eF_IMemberRepository.All();
        }

        public ICollection<Member> All(Expression<Func<Member, bool>> expression)
        {
            return _eF_IMemberRepository.All(expression);
        }

        public async Task<List<Member>> AllAsync()
        {
            return await _eF_IMemberRepository.AllAsync();
        }

        public async Task<List<Member>> AllAsync(Expression<Func<Member, bool>> expression)
        {
            return await _eF_IMemberRepository.AllAsync(expression);
        }

        public bool Delete(Member entity)
        {
            return _eF_IMemberRepository.Delete(entity);
        }

        public bool Delete(int entityID)
        {
            return _eF_IMemberRepository.Delete(entityID);
        }

        public Task<bool> DeleteAsync(Member entity)
        {
            return _eF_IMemberRepository.DeleteAsync(entity);
        }

        public Task<bool> DeleteAsync(int entityID)
        {
           return _eF_IMemberRepository.DeleteAsync(entityID);
        }

        public Member Get(int entityID)
        {
            return _eF_IMemberRepository.Get(entityID);
        }

        public Member Get(Expression<Func<Member, bool>> expression)
        {
            return _eF_IMemberRepository.Get(expression);
        }

        public async Task<Member> GetAsync(int entityID)
        {
            return await _eF_IMemberRepository.GetAsync(entityID);
        }

        public  async Task<Member> GetAsync(Expression<Func<Member, bool>> expression)
        {
            return await _eF_IMemberRepository.GetAsync(expression);
        }

        public Member getMemberMessageList(int id)
        {
            return _eF_IMemberRepository.getMemberMessageList(id);
        }

        public void Save()
        {
            _eF_IMemberRepository.Save();
        }

        public bool Update(Member entity)
        {
            return _eF_IMemberRepository.Update(entity);
        }

        public Task<bool> UpdateAsync(Member entity)
        {
            return _eF_IMemberRepository.UpdateAsync(entity);
        }
    }
}
