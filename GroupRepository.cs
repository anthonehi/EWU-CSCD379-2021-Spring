using System;
using System.Collections.Generic;
using SecretSanta.Data;
using System.Linq;

namespace SecretSanta.Business
{
    public class GroupRepository : IGroupRepository
    {
        public Random Random { get; }
        

        private User GetRandomUser() 
            => MockData.Users[Random.Next(MockData.Users.Count)];

        public Group Create(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MockData.Groups[item.Id] = item;
            return item;
        }

        public Group? GetItem(int id)
        {
            if (MockData.Groups.TryGetValue(id, out Group? user))
            {
                return user;
            }
            return null;
        }

        public ICollection<Group> List()
        {
            return MockData.Groups.Values;
        }

        public bool Remove(int id)
        {
            return MockData.Groups.Remove(id);
        }
        public Assignment? createAssignment(User give, User rec){
            Assignment newass = new Assignment(give, rec);
            return newass;
        }
    public AssignmentResult groupAssignment(int groupId)
        {
            Group? group = GetItem(groupId);
            int num = Random.Next(3);  
            int num1 = Random.Next(3);  

                User? giver = group.Users[Random.Next(MockData.Users.Count)];
                User? rec = group.Users[Random.Next(MockData.Users.Count)];
                Assignment? newass = new Assignment(giver,rec);
                group.Assignments?.Add(newass);
                return AssignmentResult.Success();
            
            
        }
        //public addtoAssignment(User)
        public void Save(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            MockData.Groups[item.Id] = item;
        }
    }
}
