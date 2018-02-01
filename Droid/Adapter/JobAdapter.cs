using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Techserv.Droid.Model;

namespace Techserv.Droid.Adapter
{
    public class JobAdapter:BaseAdapter
    {
        Activity mActivity;
        List<Job> jobs;

        public JobAdapter(Activity activity , List<Job> jobs)
        {
            this.mActivity = activity;
            this.jobs = jobs;
        }

        public override int Count => jobs.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return jobs[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            JobViewHolder holder;
            var view = convertView;

            if (view == null)
            {
                holder = new JobViewHolder();
                view = mActivity.LayoutInflater.Inflate(Resource.Layout.job_list_item, null);
                holder.Name = view.FindViewById<TextView>(Resource.Id.textView);
                view.Tag = holder;
            }
            else
            {
                holder = view.Tag as JobViewHolder;
            }

            //TODO: Set real attributes of Job to correct views which also need to be added to xml.
            holder.Name.Text = jobs[position].Id.ToString();

            return view;
        }
    }

    class JobViewHolder : Java.Lang.Object
    {
        public TextView Name { get; set; }
    }
}
