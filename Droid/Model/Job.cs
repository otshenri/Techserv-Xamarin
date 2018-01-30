using System;
namespace Techserv.Droid.Model
{
    public class Job
    {
        long id;

        public Job(long id)
        {
            this.id = id;
        }

        public long Id { get => id; set => id = value; }
    }
}
