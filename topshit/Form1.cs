using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace topshit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            HttpClientHandler handler = new HttpClientHandler();


            HttpClient client = new HttpClient(handler);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.1.1/login.cgi");

            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Cookie", "SessionID=");
            request.Headers.Add("Origin", "http://192.168.1.1");
            request.Headers.Add("Referer", "http://192.168.1.1/login.htm");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36 OPR/97.0.0.0");

            request.Content = new StringContent("usernameEncrypt=9205cc0e701acd8d6934c1f3c0d0dce6&passwordEncrypt=9205cc0e701acd8d6934c1f3c0d0dce6&submit.htm%3Flogin.htm=Send");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            MessageBox.Show(responseBody);
            System.Threading.Thread.Sleep(5000);



            HttpRequestMessage requests = new HttpRequestMessage(HttpMethod.Post, "http://192.168.1.1/form2Reboot.cgi");

            requests.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            requests.Headers.Add("Cache-Control", "max-age=0");
            requests.Headers.Add("Connection", "keep-alive");
            requests.Headers.Add("Cookie", "SessionID=");
            requests.Headers.Add("Origin", "http://192.168.1.1");
            requests.Headers.Add("Referer", "http://192.168.1.1/reboot.htm?v=1682427773000");
            requests.Headers.Add("Upgrade-Insecure-Requests", "1");
            requests.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36 OPR/97.0.0.0");

            requests.Content = new StringContent("save=Red%C3%A9marrer&submit.htm%3Freboot.htm=Send&submit.htm%3Freboot.htm=Send");
            requests.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpResponseMessage responses = await client.SendAsync(requests);
            responses.EnsureSuccessStatusCode();
            string responseBodys = await responses.Content.ReadAsStringAsync();
            MessageBox.Show(responseBodys);
        }
    }
}
