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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace LoginProgram
{
    public partial class Form3 : Form
    {
        Form1 form1;
        WinHttpRequest itemLoginRequest = new WinHttpRequest(); // 아이템매니아 로그인용 winhttp 인스턴스 생성

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Form3()
        {
            InitializeComponent();
        }

        public void SetLoginInfo(Form1 newFrom1, WinHttpRequest newItemLoginRequest) // 폼 2 에서 로그인 정보 받기
        {
            form1 = newFrom1;
            itemLoginRequest = newItemLoginRequest; // http 쿼리 저장
        }

        public void SetInstantData(String serverName, String itemType, String minBuyNum, String maxBuyNum, String sellUnit, String sellNormal) // 폼 2 에서 게시글 인스턴트 정보 받기
        {
            this.IwServerName.Text = serverName;
            this.IwItemType.Text = itemType;

            if (minBuyNum == "" && maxBuyNum == "") // 일반판매인 경우 일반금액으로 표시
            {
                this.IwCost.Text = sellNormal;
            }
            else // 분할판매인 경우 분할금액으로 표시
            {
                this.IwMinNum.Text = minBuyNum;
                this.IwMaxNum.Text = maxBuyNum;
                this.IwCost.Text = sellUnit;
            }
        }

        private void IwOkButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://trade.itemmania.com/sell/"); // 주소를 참조하여 웹브라우저 실행

            // 매크로 시작
            System.Threading.Thread.Sleep(5000); // 메크로 시작전 5초 대기

            int mouseX = Cursor.Position.X; // 첫 커서 위치 추출
            int mouseXa = Cursor.Position.X;
            int mouseY = Cursor.Position.Y;
            bool item = false;

            // 게임명 입력
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭
            // https://msdn.microsoft.com/ko-kr/library/system.windows.forms.sendkeys.send%28v=vs.110%29.aspx?cs-save-lang=1&cs-lang=csharp&f=255&MSPPError=-2147217396#code-snippet-2
            System.Threading.Thread.Sleep(1000); // 인터벌
            SendKeys.Send("e");
            SendKeys.Send("j");
            SendKeys.Send("s");
            SendKeys.Send("w");
            SendKeys.Send("j");
            SendKeys.Send("s");
            System.Threading.Thread.Sleep(500); // 인터벌
            SendKeys.Send("{DOWN}");
            SendKeys.Send("{ENTER}");
            System.Threading.Thread.Sleep(200); // 인터벌

            // 서버명 입력
            if (this.IwServerName.Text == "스타트")
            {
                SendKeys.Send("t");
                SendKeys.Send("m");
            }
            else if (this.IwServerName.Text == "디레지에")
            {
                SendKeys.Send("e");
                SendKeys.Send("l");
            }
            else if (this.IwServerName.Text == "바칼")
            {
                SendKeys.Send("q");
                SendKeys.Send("k");
            }
            else if (this.IwServerName.Text == "시로코")
            {
                SendKeys.Send("t");
                SendKeys.Send("l");
            }
            else if (this.IwServerName.Text == "안톤")
            {
                SendKeys.Send("d");
                SendKeys.Send("k");
                SendKeys.Send("s");
            }
            else if (this.IwServerName.Text == "카시야스")
            {
                SendKeys.Send("z");
                SendKeys.Send("k");
                SendKeys.Send("t");
                SendKeys.Send("l");
            }
            else if (this.IwServerName.Text == "카인")
            {
                SendKeys.Send("z");
                SendKeys.Send("k");
                SendKeys.Send("d");
                SendKeys.Send("l");
                SendKeys.Send("s");
            }
            else if (this.IwServerName.Text == "프레이")
            {
                SendKeys.Send("v");
                SendKeys.Send("m");
            }
            else if (this.IwServerName.Text == "이벤트 서버")
            {
                SendKeys.Send("d");
                SendKeys.Send("l");
            }
            else // 기타
            {
                SendKeys.Send("r");
                SendKeys.Send("l");
            }
            System.Threading.Thread.Sleep(500); // 인터벌
            SendKeys.Send("{DOWN}");
            SendKeys.Send("{ENTER}");
            System.Threading.Thread.Sleep(200); // 인터벌

            // 물품종류 입력
            mouseY += 145;
            if (this.IwItemType.Text == "골드")
            {

            }
            else if (this.IwItemType.Text == "아이템")
            {
                mouseXa = mouseX + 45;
                item = true;
            }
            else if (this.IwItemType.Text == "게임재능")
            {
                mouseXa = mouseX + 110;
                item = true;
            }
            else // 기타
            {
                mouseXa = mouseX + 170;
            }
            Cursor.Position = new Point(mouseXa, mouseY); // 마우스 위치 수정
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭
            System.Threading.Thread.Sleep(200); // 인터벌

            // 판매유형 입력
            mouseY += 33;
            if (this.IwMaxNum.Text == "") // 일반
            {
                mouseXa = mouseX;
            }
            else // 분할
            {
                mouseXa = mouseX + 45;
            }
            Cursor.Position = new Point(mouseXa, mouseY); // 마우스 위치 수정
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭
            System.Threading.Thread.Sleep(200); // 인터벌

            // 판매수량 단위 입력 (골드)
            if (item == false)
            {
                mouseY += 30;
                if (this.IwMinNum.Text.IndexOf("만") != -1) // 만
                {
                    mouseXa = mouseX + 78;
                }
                else if (this.IwMinNum.Text.IndexOf("억") != -1) // 억
                {
                    mouseXa = mouseX + 119;
                }
                else // 없음
                {
                    mouseXa = mouseX + 33;
                }
                Cursor.Position = new Point(mouseXa, mouseY); // 마우스 위치 수정
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭
                System.Threading.Thread.Sleep(200); // 인터벌

                // 판매수량 입력 (골드, 일반)
                this.IwMinNum.Text = this.IwMinNum.Text.Replace("골드", "");
                this.IwMinNum.Text = this.IwMinNum.Text.Replace("만", "");
                this.IwMinNum.Text = this.IwMinNum.Text.Replace("억", "");
                this.IwMinNum.Text = this.IwMinNum.Text.Replace(",", "");
                this.IwMinNum.Text = this.IwMinNum.Text.Replace(" ", "");
                mouseY += 23;
                Cursor.Position = new Point(mouseX, mouseY); // 마우스 위치 수정
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭
                System.Threading.Thread.Sleep(200); // 인터벌
                for (int count = 0; count < this.IwMinNum.Text.Length; count++)
                {
                    if (this.IwMinNum.Text.Substring(count, 1) == "1")
                    {
                        SendKeys.Send("1");
                    }
                    else if (this.IwMinNum.Text.Substring(count, 1) == "2")
                    {
                        SendKeys.Send("2");
                    }
                    else if (this.IwMinNum.Text.Substring(count, 1) == "3")
                    {
                        SendKeys.Send("3");
                    }
                    else if (this.IwMinNum.Text.Substring(count, 1) == "4")
                    {
                        SendKeys.Send("4");
                    }
                    else if (this.IwMinNum.Text.Substring(count, 1) == "5")
                    {
                        SendKeys.Send("5");
                    }
                    else if (this.IwMinNum.Text.Substring(count, 1) == "6")
                    {
                        SendKeys.Send("6");
                    }
                    else if (this.IwMinNum.Text.Substring(count, 1) == "7")
                    {
                        SendKeys.Send("7");
                    }
                    else if (this.IwMinNum.Text.Substring(count, 1) == "8")
                    {
                        SendKeys.Send("8");
                    }
                    else if (this.IwMinNum.Text.Substring(count, 1) == "9")
                    {
                        SendKeys.Send("9");
                    }
                    else // 0
                    {
                        SendKeys.Send("0");
                    }
                }

                // 판매수량 입력 (골드, 분할인 경우 추가로)
                if (this.IwMaxNum.Text != "")
                {
                    this.IwMaxNum.Text = this.IwMaxNum.Text.Replace("골드", "");
                    this.IwMaxNum.Text = this.IwMaxNum.Text.Replace("만", "");
                    this.IwMaxNum.Text = this.IwMaxNum.Text.Replace("억", "");
                    this.IwMaxNum.Text = this.IwMaxNum.Text.Replace(",", "");
                    this.IwMaxNum.Text = this.IwMaxNum.Text.Replace(" ", "");
                    mouseXa = mouseX + 220;
                    Cursor.Position = new Point(mouseXa, mouseY); // 마우스 위치 수정
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭
                    System.Threading.Thread.Sleep(200); // 인터벌
                    for (int count = 0; count < this.IwMaxNum.Text.Length; count++)
                    {
                        if (this.IwMaxNum.Text.Substring(count, 1) == "1")
                        {
                            SendKeys.Send("1");
                        }
                        else if (this.IwMaxNum.Text.Substring(count, 1) == "2")
                        {
                            SendKeys.Send("2");
                        }
                        else if (this.IwMaxNum.Text.Substring(count, 1) == "3")
                        {
                            SendKeys.Send("3");
                        }
                        else if (this.IwMaxNum.Text.Substring(count, 1) == "4")
                        {
                            SendKeys.Send("4");
                        }
                        else if (this.IwMaxNum.Text.Substring(count, 1) == "5")
                        {
                            SendKeys.Send("5");
                        }
                        else if (this.IwMaxNum.Text.Substring(count, 1) == "6")
                        {
                            SendKeys.Send("6");
                        }
                        else if (this.IwMaxNum.Text.Substring(count, 1) == "7")
                        {
                            SendKeys.Send("7");
                        }
                        else if (this.IwMaxNum.Text.Substring(count, 1) == "8")
                        {
                            SendKeys.Send("8");
                        }
                        else if (this.IwMaxNum.Text.Substring(count, 1) == "9")
                        {
                            SendKeys.Send("9");
                        }
                        else // 0
                        {
                            SendKeys.Send("0");
                        }
                    }
                }

                // 판매금액 입력 (골드, 일반)
                mouseY += 33;
                System.Threading.Thread.Sleep(200); // 인터벌
                Cursor.Position = new Point(mouseX, mouseY); // 마우스 위치 수정
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭
                this.IwCost.Text = this.IwCost.Text.Replace("원", "");
                this.IwCost.Text = this.IwCost.Text.Replace("만", "");
                this.IwCost.Text = this.IwCost.Text.Replace("억", "");
                this.IwCost.Text = this.IwCost.Text.Replace(",", "");
                this.IwCost.Text = this.IwCost.Text.Replace(" ", "");
                // 당(분할) 이 아닌 경우
                if (this.IwCost.Text.IndexOf("당") == -1)
                {
                    for (int count = 0; count < this.IwCost.Text.Length; count++)
                    {
                        if (this.IwCost.Text.Substring(count, 1) == "1")
                        {
                            SendKeys.Send("1");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "2")
                        {
                            SendKeys.Send("2");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "3")
                        {
                            SendKeys.Send("3");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "4")
                        {
                            SendKeys.Send("4");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "5")
                        {
                            SendKeys.Send("5");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "6")
                        {
                            SendKeys.Send("6");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "7")
                        {
                            SendKeys.Send("7");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "8")
                        {
                            SendKeys.Send("8");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "9")
                        {
                            SendKeys.Send("9");
                        }
                        else // 0
                        {
                            SendKeys.Send("0");
                        }
                    }
                }
                else // 분할인 경우
                {
                    for (int count = 0; count < this.IwCost.Text.IndexOf("당"); count++)
                    {
                        if (this.IwCost.Text.Substring(count, 1) == "1")
                        {
                            SendKeys.Send("1");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "2")
                        {
                            SendKeys.Send("2");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "3")
                        {
                            SendKeys.Send("3");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "4")
                        {
                            SendKeys.Send("4");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "5")
                        {
                            SendKeys.Send("5");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "6")
                        {
                            SendKeys.Send("6");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "7")
                        {
                            SendKeys.Send("7");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "8")
                        {
                            SendKeys.Send("8");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "9")
                        {
                            SendKeys.Send("9");
                        }
                        else // 0
                        {
                            SendKeys.Send("0");
                        }
                    }

                    mouseXa = mouseX + 140;
                    System.Threading.Thread.Sleep(200); // 인터벌
                    Cursor.Position = new Point(mouseXa, mouseY); // 마우스 위치 수정
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭

                    for (int count = this.IwCost.Text.IndexOf("당") + 1; count < this.IwCost.Text.Length; count++)
                    {
                        if (this.IwCost.Text.Substring(count, 1) == "1")
                        {
                            SendKeys.Send("1");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "2")
                        {
                            SendKeys.Send("2");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "3")
                        {
                            SendKeys.Send("3");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "4")
                        {
                            SendKeys.Send("4");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "5")
                        {
                            SendKeys.Send("5");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "6")
                        {
                            SendKeys.Send("6");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "7")
                        {
                            SendKeys.Send("7");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "8")
                        {
                            SendKeys.Send("8");
                        }
                        else if (this.IwCost.Text.Substring(count, 1) == "9")
                        {
                            SendKeys.Send("9");
                        }
                        else // 0
                        {
                            SendKeys.Send("0");
                        }
                    }
                }
            }

            // 판매금액 입력 (아이템 일반)
            if (item = true && this.IwMaxNum.Text == "")
            {
                mouseY += 33;
                System.Threading.Thread.Sleep(200); // 인터벌
                Cursor.Position = new Point(mouseX, mouseY); // 마우스 위치 수정
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)mouseX, (uint)mouseY, 0, 0); // 마우스 클릭
                this.IwCost.Text = this.IwCost.Text.Replace("원", "");
                this.IwCost.Text = this.IwCost.Text.Replace("만", "");
                this.IwCost.Text = this.IwCost.Text.Replace("억", "");
                this.IwCost.Text = this.IwCost.Text.Replace(",", "");
                this.IwCost.Text = this.IwCost.Text.Replace(" ", "");
                for (int count = 0; count < this.IwCost.Text.Length; count++)
                {
                    if (this.IwCost.Text.Substring(count, 1) == "1")
                    {
                        SendKeys.Send("1");
                    }
                    else if (this.IwCost.Text.Substring(count, 1) == "2")
                    {
                        SendKeys.Send("2");
                    }
                    else if (this.IwCost.Text.Substring(count, 1) == "3")
                    {
                        SendKeys.Send("3");
                    }
                    else if (this.IwCost.Text.Substring(count, 1) == "4")
                    {
                        SendKeys.Send("4");
                    }
                    else if (this.IwCost.Text.Substring(count, 1) == "5")
                    {
                        SendKeys.Send("5");
                    }
                    else if (this.IwCost.Text.Substring(count, 1) == "6")
                    {
                        SendKeys.Send("6");
                    }
                    else if (this.IwCost.Text.Substring(count, 1) == "7")
                    {
                        SendKeys.Send("7");
                    }
                    else if (this.IwCost.Text.Substring(count, 1) == "8")
                    {
                        SendKeys.Send("8");
                    }
                    else if (this.IwCost.Text.Substring(count, 1) == "9")
                    {
                        SendKeys.Send("9");
                    }
                    else // 0
                    {
                        SendKeys.Send("0");
                    }
                }
            }
        }
    }
}
