﻿using LunchScheduler.Model;
using LunchScheduler.Service;
using LunchScheduler.Service.ResponseModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.ViewModel
{
    public class StaffMainPageViewModel : BaseViewModel
    {
        public StaffMainPageViewModel()
        {
            //OrderData = new ObservableCollection<StaffModel>();
            //OrderData.Add(new StaffModel()
            //{
            //    ItemName = "item 1",
            //    ScheduleTime = "24 May 2022"

            //}) ;


            //OrderData.Add(new StaffModel()
            //{
            //    ItemName = "item 2",
            //    ScheduleTime = "26 May 2022"

            //});

            OrderData = new ObservableCollection<ItemModel>();
             getItems();

        }


        ObservableCollection<ItemModel> _orderData;
        public ObservableCollection<ItemModel> OrderData
        {
            get { return _orderData; }
            set
            {
                _orderData = value;
                OnPropertyChanged();
            }
        }

        public async void getItems()
        {
            try
            {
                var web = new AccountService();
                var result = await web.getItemsApi(2);
                if (result != null)
                {

                    OrderData = new ObservableCollection<ItemModel>(result.data);


                }
                else
                {
                    // api is down
                    DisplayAlert("alert", "system not working", "ok");
                }
            }
            catch(Exception e)
            {

            }
        }

        private void DisplayAlert(string v1, object message, string v2)
        {
            throw new NotImplementedException();
        }
    }
}