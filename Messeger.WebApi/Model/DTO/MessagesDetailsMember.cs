using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messeger.WebApi.Model.DTO
{
    public class MessagesDetailsMember
    {
        public MessagesMember DataMessageMemberDetails { get; set; }
        public List<MessageDetails> DataMessageDetails { get; set; }
        public List<Members> DataMembers { get; set; }
    }


    public class MessageDetails
    {
        public int MemberID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Text { get; set; }
        public DateTime CreaterDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
