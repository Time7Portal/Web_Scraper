using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHttp;

namespace LoginProgram
{
    public partial class Form1 : Form
    {
        WinHttpRequest naverLoginRequest = new WinHttpRequest(); // 네이버 로그인용 winhttp 인스턴스 생성
        WinHttpRequest itemLoginRequest = new WinHttpRequest(); // 아이템매니아 로그인용 winhttp 인스턴스 생성

        public Form1()
        {
            InitializeComponent();
        }

        private void NaverLoginButton_Click(object sender, EventArgs e) // 버튼이 클릭됬을때 발생되는 이벤트
        {
            Form2 form2 = new Form2(this); // 게시글 표시용 폼 생성
            bool isILoginSucess = false; // 아이템매니아 로그인 성공 여부 저장

            // 네이버 로그인 시작
            String nID = this.NaverLoginId.Text;
            String nPW = this.NaverLoginPw.Text;
            String nSendString = "enctp=1" + "&encpw=0" + "&encnm=0" + "&svctype=0" + "&svc=0" + "&viewtype=0" + "&postDataKey=0" + "&smart_LEVEL=-1" + "&logintp=0" + "&localechange=0" + "&theme_mode=0" + "&ls=0" + "&pre_id=0" + "&resp=0" + "&exp=0" + "&ru=0" + "&id=" + nID + "&pw=" + nPW + "&nvlong=on";

            if (nID != "") // 아이디를 적은 경우만 로그인 시도
            {
                naverLoginRequest.Open("POST", "https://nid.naver.com/nidlogin.login"); // 웹을 POST로 요청
                naverLoginRequest.SetRequestHeader("Referer", "https://nid.naver.com/nidlogin.login"); // 헤더 할당
                naverLoginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                naverLoginRequest.SetRequestHeader("User-Agent", "Mozilla/5.0");
                naverLoginRequest.Send(nSendString); // 문자열 전송
                naverLoginRequest.WaitForResponse();

                String nLoginData = naverLoginRequest.ResponseText; // 네이버 로부터 받은 데이터 저장

                if (-1 == nLoginData.IndexOf("window.location.replace")) // 네이버 로그인에 실패한 경우
                {
                    MessageBox.Show("네이버 로그인 실패");
                }
            }

            // 아이템매니아 로그인 시작
            String iID = this.ItemLoginId.Text;
            String iPW = this.ItemLoginPw.Text;
            String iSendString = "plogin_kr=0" + "&user_id=" + iID + "&user_password=" + iPW + "&id_save=ok";

            if (iID != "") // 아이디를 적은 경우만 로그인 시도
            {
                itemLoginRequest.Open("POST", "https://www.itemmania.com/portal/user/login_form_ok.php"); // 웹을 POST로 요청
                itemLoginRequest.SetRequestHeader("Referer", "https://www.itemmania.com/portal/user/p_login_form.html"); // 헤더 할당
                itemLoginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                itemLoginRequest.SetRequestHeader("User-Agent", "Mozilla/5.0");
                itemLoginRequest.Send(iSendString); // 문자열 전송
                itemLoginRequest.WaitForResponse();

                String iLoginData = itemLoginRequest.ResponseText; // 아이템매니아 로부터 받은 데이터 저장
                if (-1 == iLoginData.IndexOf("location.href='http://www.itemmania.com'")) // 아이템매니아 로그인에 성공한 경우
                {
                    MessageBox.Show("아이템매니아 로그인 실패");
                }
                else
                {
                    isILoginSucess = true; // 로그인 성공 여부 저장
                }
            }
            else
            {
                MessageBox.Show("최소한 아이템매니아 로그인은 필요합니다");
            }

            // 로그인이 성공한 경우
            if (isILoginSucess == true)
            {
                // 폼 전환
                this.Hide();
                form2.Show();

                // 폼 2 에 winhttp 인스턴스를 넘김
                form2.SetLoginInfo(this, naverLoginRequest, itemLoginRequest);
            }
        }

        private void LoginButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NaverLoginButton_Click(sender, e);
            }
        }
    }
}
