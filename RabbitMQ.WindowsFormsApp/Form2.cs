using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RabbitMQ.WindowsFormsApp
{
    public partial class Form2 : Form
    {
        ConnectionFactory connectionFactory = new ConnectionFactory();
        bool sendFlag = true;
        bool receivedFlag = true;
        public Form2()
        {
            InitializeComponent();
            connectionFactory.HostName = "localhost";
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var durable = true;
                    channel.QueueDeclare("ModelTest", durable, false, false, null);
                    //channel.ExchangeDeclare("ModelTest", ExchangeType.Fanout);
                    var properties = channel.CreateBasicProperties();
                    properties.SetPersistent(true);

                    //new Thread(() =>
                    //{
                    while (sendFlag)
                    {
                        string message = "Hello world => " + Guid.NewGuid().ToString() + " \r\n";

                        channel.BasicPublish("ModelTest", "", null, Encoding.UTF8.GetBytes(message));
                        Action<string> action = (data) =>
                        {
                            textBox1.AppendText(data);
                        };
                        Invoke(action, "发送:" + message);
                        Thread.Sleep(5000);
                    }
                    //})
                    //{ IsBackground = true }.Start();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var durable = true;
                    channel.QueueDeclare("ModelTest", durable, false, false, null);
                    channel.BasicQos(0, 1, false);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("ModelTest", false, consumer);

                    while (receivedFlag)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Action<string> action = (data) =>
                        {
                            textBox2.AppendText(data);
                        };
                        Invoke(action, "接收:" + message);

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
            }
        }
    }
}
