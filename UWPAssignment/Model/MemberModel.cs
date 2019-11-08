using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using UWPAssignment.Entity;
using UWPAssignment.Utils;

namespace UWPAssignment.Model
{
    class MemberModel
    {
        public bool Insert(Member member)
        {
            try
            {
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("INSERT INTO Members (FirstName, LastName, Avatar, Phone, " +
                                                                             "Address, Introduction, Gender, Birthday, Email, Password) VALUES (?,?,?,?,?,?,?,?,?,?)"))
                {
                    stt.Bind(1, member.FirstName);
                    stt.Bind(2, member.LastName);
                    stt.Bind(3, member.Avatar);
                    stt.Bind(4, member.Phone);
                    stt.Bind(5, member.Address);
                    stt.Bind(6, member.Introduction);
                    stt.Bind(7, member.Gender);
                    stt.Bind(8, member.Birthday);
                    stt.Bind(9, member.Email);
                    stt.Bind(10, member.Password);
                    stt.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public ObservableCollection<Member> ReadMember()
        {
            ObservableCollection<Member> list = new ObservableCollection<Member>();

            using (var conn = new SQLiteConnection("note.db", SQLiteOpen.READWRITE))
            {
                using (var statement = conn.Prepare(@"Select * from Note;"))
                {
                    while (statement.Step() == SQLiteResult.ROW)
                    {
                        list.Add(new Member()
                        {
                            Email = (string)statement[1],
                            LastName = (string)statement[2],
                        });
                    }
                }
            }
            return list;
        }
    }
}
