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

namespace LoginProgram
{
    public partial class Form2 : Form
    {
        Form1 form1; // 로그인 폼 정의
        Form3 form3; // 게시글 작성 폼 정의
        WinHttpRequest naverLoginRequest = new WinHttpRequest(); // 네이버 로그인용 winhttp 인스턴스 생성
        WinHttpRequest itemLoginRequest = new WinHttpRequest(); // 아이템매니아 로그인용 winhttp 인스턴스 생성

        String ncData = ""; // 네이버 카페 에서 받은 데이터 저장
        String itData = ""; // 아이템매니아에서 받은 데이터 저장
        String itwData = ""; // 게시글 작성을 위해 받은 데이터 저장

        int nFindCount; // 네이버 카페 문자열 찾은 수
        String[] nTitles; // 네이버 카페 게시글 목록 저장
        String[] nUrlLinks; // 네이버 카페 URL 저장

        int iFindCount; // 아이템매니아 문자열 찾은 수
        String[] iTitles; // 아이템매니아 게시글 목록 저장
        String[] iFinalTitles; // 아이템매니아 실제 표시내용 저장
        String[] iUrlLinks; // 아이템매니아 URL 목록 저장

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 pForm)
        {
            form1 = pForm;
            InitializeComponent();
        }

        public void SetLoginInfo(Form1 form1, WinHttpRequest newNaverLoginRequest, WinHttpRequest newItemLoginRequest) // 폼 1 에서 로그인 정보 받기
        {
            // http 쿼리 저장
            naverLoginRequest = newNaverLoginRequest;
            itemLoginRequest = newItemLoginRequest;
        }

        private void NaverCafeLinkButton_Click(object sender, EventArgs e)
        {
            // 카페 게시글 http로 읽어오기
            naverLoginRequest.Open("GET", "http://m.cafe.naver.com/ArticleList.nhn?search.clubid=11276312&search.menuid=403&search.boardtype=L"); // 웹을 POST로 요청
            naverLoginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            naverLoginRequest.SetRequestHeader("User-Agent", "Mozilla/5.0");
            naverLoginRequest.Send();
            naverLoginRequest.WaitForResponse();

            // 받은 데이터 저장
            ncData = naverLoginRequest.ResponseText;
            this.DebugBox.Text = ncData;// 데이터 임시 미리보기

            // 특정 문자열 검색된 경우
            String nSerchStr = "<span class=\"ic_new\">New</span>";

            // new 게시글의 제목 (해당 문자열) 탐색
            if (-1 != ncData.IndexOf(nSerchStr))
            {
                // 해당 문자열 찾은 갯수 카운트
                MatchCollection matches = Regex.Matches(ncData, nSerchStr);
                nFindCount = matches.Count;
                this.CafeLabel.Text = "카페 게시글 (" + nFindCount.ToString() + "개 찾았습니다)";

                // 해당 문자열 갯수만큼 제목 모두 찾기
                int seeqCount = 0; // 몇번째 문자열을 찾고 있는지 카운트
                int titleCutStart = 0; // 자르기 첫 위치 저장
                int titleCutLast = 0; // 자르기 마지막 위치 저장
                int urlSeeqCount = 0;
                int urlTitleCutStart = 0;
                int urlTitleCutLast = 0;

                nTitles = new String[nFindCount]; // 찾은 제목을 저장할 배열
                nUrlLinks = new String[nFindCount]; // 찾은 URL을 저장할 배열

                this.CafeListBox.Items.Clear(); // 리스트박스 초기화

                // 게시글 제목과 URL 파스
                for (int count = 1; count < nFindCount; count++)
                {
                    // 제목 찾기
                    seeqCount = ncData.IndexOf("</strong>", seeqCount + 1); // 찾은 문자열의 해당 번째 위치 반환해 다음 위치 참조
                    titleCutStart = ncData.IndexOf("<strong>", seeqCount) + 8; // 자르기 첫 위치 추출
                    titleCutLast = ncData.IndexOf("</strong>", titleCutStart); // 자르기 마지막 위치 추출

                    // URL 찾기
                    urlSeeqCount = ncData.IndexOf("<a href=\"/ArticleRead.nhn?", urlSeeqCount + 1); // 찾은 문자열의 해당 번째 위치 반환해 다음 위치 참조
                    urlTitleCutStart = ncData.IndexOf("<a href=\"/ArticleRead.nhn?", urlSeeqCount) + 10; // 자르기 첫 위치 추출
                    urlTitleCutLast = ncData.IndexOf("&boardtype=L", urlTitleCutStart); // 자르기 마지막 위치 추출

                    // 공지가 아닌 경우만 저장
                    if (-1 == ncData.IndexOf("<span class=\"ic_noti\">공지</span>", titleCutStart, titleCutLast - titleCutStart))
                    {
                        // 제목 저장 시작
                        nTitles[count - 1] = ncData.Substring(titleCutStart, titleCutLast - titleCutStart).Trim(); // 제목 텍스트 저장
                        nTitles[count - 1] = nTitles[count - 1].Replace("\t", ""); // 들여쓰기 제거
                        nTitles[count - 1] = nTitles[count - 1].Replace("\n", ""); // 개행 제거
                        nTitles[count - 1] = nTitles[count - 1].Replace("&nbsp", ""); // 개행 제거

                        // URL 저장 시작
                        nUrlLinks[count - 1] = ncData.Substring(urlTitleCutStart, urlTitleCutLast - urlTitleCutStart); // 제목 텍스트 저장

                        this.CafeListBox.Items.Add(nTitles[count - 1]); // 리스트 박스에 출력
                    }
                    else // 공지가 걸린 경우 배열 카운터 추가 안함
                    {
                        count--;
                    }
                }
            }
            else
            {
                MessageBox.Show("최근 게시글 못찾음");
                // 시스템 시간 추출
                //MessageBox.Show("현재 시간" + System.DateTime.Now.ToString("hh:mm"));
                //String nowTime = System.DateTime.Now.ToString("hh:mm");
            }
        }

        private void NaverCafeListBox_DoubleClick(object sender, EventArgs e)
        {
            // 선택된 리스트가 있는 경우
            if (CafeListBox.SelectedItem != null)
            {
                // 선택된 내용이 몇번인지 찾기
                for (int count = 0; count < nFindCount; count ++)
                {
                    if (CafeListBox.SelectedItem.ToString() == nTitles[count]) // 리스트의 내용 비교해서 번호 찾기
                    {
                        //MessageBox.Show("http://m.cafe.naver.com/" + nUrlLinks[count]);
                        System.Diagnostics.Process.Start("http://m.cafe.naver.com/" + nUrlLinks[count + 1]); // 주소를 참조하여 웹브라우저 실행
                    }
                }
            }
        }

        private void ItemRefreshButton_Click(object sender, EventArgs e)
        {
            // 아이템매니아 게시글 http로 읽어오기
            itemLoginRequest.Open("POST", "http://trade.itemmania.com/sell/list.html"); // 웹을 POST로 요청
            itemLoginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            itemLoginRequest.SetRequestHeader("User-Agent", "Mozilla/5.0");
            String iSendString = "search_type=sell&" + "search_game=281&" + "search_goods=all&" + "search_word=" + this.ItemSearch.Text;
            itemLoginRequest.Send(iSendString);
            itemLoginRequest.WaitForResponse();

            itData = itemLoginRequest.ResponseText; // 아이템매니아로부터 받은 데이터 저장
            this.DebugBox.Text = itData;// 데이터 임시 미리보기

            // 특정 문자열 검색된 경우
            String iSerchStr = "<td class=\"first \">";

            // new 게시글의 제목 (해당 문자열) 탐색
            if (-1 != itData.IndexOf(iSerchStr))
            {
                // 해당 문자열 찾은 갯수 카운트
                MatchCollection matches = Regex.Matches(itData, iSerchStr);
                iFindCount = matches.Count;
                this.ItemLabel.Text = "아이템매니아 게시글 (" + iFindCount.ToString() + "개 찾았습니다)";

                // 해당 문자열 갯수만큼 제목 모두 찾기
                int seeqCount = 0; // 몇번째 문자열을 찾고 있는지 카운트
                int titleCutStart = 0; // 자르기 첫 위치 저장
                int titleCutLast = 0; // 자르기 마지막 위치 저장
                int urlCutStart = 0; // 자르기 첫 위치 저장
                int urlCutLast = 0; // 자르기 마지막 위치 저장

                iTitles = new String[iFindCount]; // 찾은 제목을 저장할 배열
                iFinalTitles = new String[iFindCount]; // 완성한 제목을 저장할 배열
                iUrlLinks = new String[iFindCount]; // URL을 저장할 배열

                this.ItemListBox.Items.Clear(); // 리스트박스 초기화

                // 게시글 제목 파스
                for (int count = 0; count < iFindCount; count++)
                {
                    // 카테고리 찾아서 저장
                    seeqCount = itData.IndexOf(iSerchStr, seeqCount + 1); // 찾은 문자열의 해당 번째 위치 반환해 다음 위치 참조
                    titleCutStart = itData.IndexOf("<td class=\"first \">", seeqCount) + 19; // 자르기 첫 위치 추출
                    titleCutLast = itData.IndexOf("<td class=\" \">", titleCutStart); // 자르기 마지막 위치 추출
                    if(titleCutLast == -1) // 마지막 위치 추출 불가할 경우
                    {
                        MessageBox.Show("검색이 불가능한 단어");// 검색 오류
                        break;
                    }
                    iTitles[count] = itData.Substring(titleCutStart, titleCutLast - titleCutStart).Trim(); // 카테고리 텍스트 저장
                    iTitles[count] = iTitles[count].Replace("\t", ""); // 들여쓰기 제거
                    iTitles[count] = iTitles[count].Replace("\n", ""); // 개행 제거

                    // URL 찾아서 저장
                    urlCutStart = iTitles[count].IndexOf("onclick=\"$.fnViewId('") + 21; // 자르기 첫 위치 추출
                    urlCutLast = iTitles[count].IndexOf("');\" class=\"\">", urlCutStart); // 자르기 마지막 위치 추출
                    iUrlLinks[count] = iTitles[count].Substring(urlCutStart, urlCutLast - urlCutStart); // 카테고리 텍스트 저장

                    // 카테고리중 서버만 전부 검색해 추출
                    if (-1 != iTitles[count].IndexOf("스타트"))
                    {
                        iFinalTitles[count] = "스타트/ ";
                    }
                    else if (-1 != iTitles[count].IndexOf("디레지에"))
                    {
                        iFinalTitles[count] = "디레지/ ";
                    }
                    else if (-1 != iTitles[count].IndexOf("바칼"))
                    {
                        iFinalTitles[count] = "바칼  / ";
                    }
                    else if (-1 != iTitles[count].IndexOf("시로코"))
                    {
                        iFinalTitles[count] = "시로코/ ";
                    }
                    else if (-1 != iTitles[count].IndexOf("안톤"))
                    {
                        iFinalTitles[count] = "안톤  / ";
                    }
                    else if (-1 != iTitles[count].IndexOf("카시야스"))
                    {
                        iFinalTitles[count] = "카시야/ ";
                    }
                    else if (-1 != iTitles[count].IndexOf("카인"))
                    {
                        iFinalTitles[count] = "카인  / ";
                    }
                    else if (-1 != iTitles[count].IndexOf("프레이"))
                    {
                        iFinalTitles[count] = "프레이/ ";
                    }
                    else if (-1 != iTitles[count].IndexOf("힐더"))
                    {
                        iFinalTitles[count] = "힐더  / ";
                    }
                    else if (-1 != iTitles[count].IndexOf("이벤트 서버"))
                    {
                        iFinalTitles[count] = "이벤트/ ";
                    }
                    else
                    {
                        iFinalTitles[count] = "기타  / ";
                    }

                    // 판매금액만 추출
                    if (-1 != iTitles[count].IndexOf("<td class=\"s_right  g_red1\">"))
                    {
                        // 특정 문자열 검색된 경우 필요한 문자열만 찾아서 저장
                        titleCutStart = iTitles[count].IndexOf("<td class=\"s_right  g_red1\">") + 28; // 자르기 첫 위치 추출
                        titleCutLast = iTitles[count].IndexOf("</td>", titleCutStart); // 자르기 마지막 위치 추출
                        iFinalTitles[count] += iTitles[count].Substring(titleCutStart, titleCutLast - titleCutStart).Trim() + " "; // 제목 텍스트 저장
                    }

                    // 제목 내용만 추출
                    if (-1 != iTitles[count].IndexOf("&#160;"))
                    {
                        // 특정 문자열 검색된 경우 필요한 문자열만 찾아서 저장
                        titleCutStart = iTitles[count].LastIndexOf("&#160;") + 6; // 자르기 첫 위치 추출
                        titleCutLast = iTitles[count].IndexOf("</a>", titleCutStart); // 자르기 마지막 위치 추출
                        iFinalTitles[count] += iTitles[count].Substring(titleCutStart, titleCutLast - titleCutStart).Trim(); // 제목 텍스트 저장
                    }
                    else // 그 밖에 특수한 상황
                    {
                        // 특정 문자열 검색된 경우 필요한 문자열만 찾아서 저장
                        titleCutStart = iTitles[count].LastIndexOf("');\" class=\"\">") + 14; // 자르기 첫 위치 추출
                        titleCutLast = iTitles[count].IndexOf("</a>", titleCutStart); // 자르기 마지막 위치 추출
                        iFinalTitles[count] += iTitles[count].Substring(titleCutStart, titleCutLast - titleCutStart).Trim(); // 제목 텍스트 저장
                    }

                    // 필요없는 기능문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("&#039;", ""); // &#039; 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("</span>", ""); // </span> 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("</font>", ""); // </font> 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("<font class='g_blue1'>", ""); // <font class='g_blue1'> 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("<span class='bold_txt'>", ""); // <span class='bold_txt'> 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("<span class='list_highlight'>", ""); // <span class='list_highlight'> 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("<span style='color:#298B7C'>", ""); // <span style='color:#298B7C'> 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("█", ""); // █ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("◘", ""); // ◘ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("■", ""); // ■ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("◆", ""); // ◆ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("★", ""); // █ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("◀", ""); // ◀ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("●", ""); // ● 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("▶", ""); // ▶ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("◁", ""); // ◁ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("○", ""); // ○ 문자 제거
                    iFinalTitles[count] = iFinalTitles[count].Replace("▷", ""); // ▷ 문자 제거

                    // 리스트 추가
                    this.ItemListBox.Items.Add(iFinalTitles[count]);
                }
            }
            else
            {
                MessageBox.Show("최근 게시글 못찾음");
                // 시스템 시간 추출
                //MessageBox.Show("현재 시간" + System.DateTime.Now.ToString("hh:mm"));
                //String nowTime = System.DateTime.Now.ToString("hh:mm");
            }
        }

        private void ItemListBox_DoubleClick(object sender, EventArgs e)
        {
            // 선택된 리스트가 있는 경우
            if (ItemListBox.SelectedItem != null)
            {
                // 선택된 내용이 몇번인지 찾기
                for (int count = 0; count < iFindCount; count++)
                {
                    if (ItemListBox.SelectedItem.ToString() == iFinalTitles[count]) // 리스트의 내용 비교해서 번호 찾기
                    {
                        //MessageBox.Show("http://trade.itemmania.com/sell/view.html?id=" + iUrlLinks[count]);
                        System.Diagnostics.Process.Start("http://trade.itemmania.com/sell/view.html?id=" + iUrlLinks[count]); // 주소를 참조하여 웹브라우저 실행
                    }
                }
            }
        }

        private void ItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ItemRefreshButton_Click(sender, e);
            }
        }

        private void ItemListBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터 키가 눌린 경우
            if (e.KeyCode == Keys.Enter)
            {
                // 선택된 리스트가 있는 경우
                if (ItemListBox.SelectedItem != null)
                {
                    // 게시글 작성 폼 표시
                    form3 = new Form3();
                    form3.Show();
                    form3.SetLoginInfo(form1, itemLoginRequest);

                    // 선택된 내용이 몇번인지 찾기
                    for (int countA = 0; countA < iFindCount; countA++)
                    {
                        if (ItemListBox.SelectedItem.ToString() == iFinalTitles[countA]) // 리스트의 내용 비교해서 번호 찾기
                        {
                            // 아이템매니아 게시글 http로 읽어오기
                            itemLoginRequest.Open("Get", "http://trade.itemmania.com/sell/view.html?id=" + iUrlLinks[countA]); // 웹을 Get로 요청
                            itemLoginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                            itemLoginRequest.SetRequestHeader("User-Agent", "Mozilla/5.0");
                            itemLoginRequest.Send();
                            itemLoginRequest.WaitForResponse();

                            itwData = itemLoginRequest.ResponseText;
                            this.DebugBox.Text = itwData;

                            int titleCutStart = 0; // 자르기 첫 위치 저장
                            int titleCutLast = 0; // 자르기 마지막 위치 저장

                            // 카테고리 찾아서 저장
                            titleCutStart = itwData.IndexOf("<td colspan=\"3\">던전앤파이터 > ") + 25; // 자르기 첫 위치 추출
                            titleCutLast = itwData.IndexOf("</td>", titleCutStart); // 자르기 마지막 위치 추출
                            if (titleCutLast == -1) // 마지막 위치 추출 불가할 경우
                            {
                                MessageBox.Show("검색이 불가능한 단어"); // 검색 오류
                                break;
                            }
                            String writeData = itwData.Substring(titleCutStart, titleCutLast - titleCutStart); // 카테고리 텍스트 잘라 저장
                            String serverName = "";
                            String itemType = "";
                            String minBuyNum = "";
                            String maxBuyNum = "";
                            String sellUnit = "";
                            String sellNormal = "";

                            // 서버명 파악
                            if (-1 != writeData.IndexOf("스타트"))
                            {
                                serverName = "스타트";
                            }
                            else if (-1 != writeData.IndexOf("디레지에"))
                            {
                                serverName = "디레지에";
                            }
                            else if (-1 != writeData.IndexOf("바칼"))
                            {
                                serverName = "바칼";
                            }
                            else if (-1 != writeData.IndexOf("시로코"))
                            {
                                serverName = "시로코";
                            }
                            else if (-1 != writeData.IndexOf("안톤"))
                            {
                                serverName = "안톤";
                            }
                            else if (-1 != writeData.IndexOf("카시야스"))
                            {
                                serverName = "카시야스";
                            }
                            else if (-1 != writeData.IndexOf("카인"))
                            {
                                serverName = "카인";
                            }
                            else if (-1 != writeData.IndexOf("프레이"))
                            {
                                serverName = "프레이";
                            }
                            else if (-1 != writeData.IndexOf("힐더"))
                            {
                                serverName = "힐더";
                            }
                            else if (-1 != writeData.IndexOf("이벤트 서버"))
                            {
                                serverName = "이벤트 서버";
                            }
                            else
                            {
                                serverName = "기타";
                            }

                            // 아이템 종류 파악
                            if (-1 != writeData.IndexOf("게임머니"))
                            {
                                itemType = "골드";
                            }
                            else if (-1 != writeData.IndexOf("아이템"))
                            {
                                itemType = "아이템";
                            }
                            else if (-1 != writeData.IndexOf("재능"))
                            {
                                itemType = "게임재능";
                            }
                            else
                            {
                                itemType = "기타";
                            }
                            
                            // 최소구매수량 추출 (분할만)
                            titleCutStart = itwData.IndexOf("<th>최소구매수량</th>") + 15; // 자르기 첫 위치 추출
                            titleCutLast = itwData.IndexOf("</td>", titleCutStart); // 자르기 마지막 위치 추출
                            if (titleCutStart != 15-1) // 첫 위치 검색 가능할 경우
                            {
                                minBuyNum = itwData.Substring(titleCutStart, titleCutLast - titleCutStart).Trim(); // 카테고리 텍스트 잘라 저장
                                minBuyNum = minBuyNum.Replace("<td>", "");
                                minBuyNum = minBuyNum.Replace("\n", "");
                                minBuyNum = minBuyNum.Replace("\t", "");
                                minBuyNum = minBuyNum.Replace(",", "");
                            }

                            // 최대구매수량 추출 (분할만)
                            titleCutStart = itwData.IndexOf("<th class=\"bd_left\">최대구매수량</th>") + 31; // 자르기 첫 위치 추출
                            titleCutLast = itwData.IndexOf("</td>", titleCutStart); // 자르기 마지막 위치 추출
                            if (titleCutStart != 31-1) // 첫 위치 검색 가능할 경우
                            {
                                maxBuyNum = itwData.Substring(titleCutStart, titleCutLast - titleCutStart).Trim(); // 카테고리 텍스트 잘라 저장
                                maxBuyNum = maxBuyNum.Replace("<td>", "");
                                maxBuyNum = maxBuyNum.Replace("\n", "");
                                maxBuyNum = maxBuyNum.Replace("\t", "");
                                maxBuyNum = maxBuyNum.Replace(",", "");
                            }

                            // 단위금액 추출 (분할만)
                            titleCutStart = itwData.IndexOf("<th class=\"bd_left\">단위금액</th>") + 29; // 자르기 첫 위치 추출
                            titleCutLast = itwData.IndexOf("</td>", titleCutStart); // 자르기 마지막 위치 추출
                            if (titleCutStart != 29-1) // 첫 위치 검색 가능할 경우
                            {
                                sellUnit = itwData.Substring(titleCutStart, titleCutLast - titleCutStart).Trim(); // 카테고리 텍스트 잘라 저장
                                sellUnit = sellUnit.Replace("<td>", "");
                                sellUnit = sellUnit.Replace("\n", "");
                                sellUnit = sellUnit.Replace("\t", "");
                                sellUnit = sellUnit.Replace(",", "");
                            }

                            // 일반금액 추출 (일반만)
                            titleCutStart = itwData.IndexOf("<th>구매금액</th>") + 13; // 자르기 첫 위치 추출
                            titleCutLast = itwData.IndexOf("</td>", titleCutStart); // 자르기 마지막 위치 추출
                            if (titleCutStart != 13-1) // 첫 위치 검색 가능할 경우
                            {
                                sellNormal = itwData.Substring(titleCutStart, titleCutLast - titleCutStart).Trim(); // 카테고리 텍스트 잘라 저장
                                sellNormal = sellNormal.Replace("<td colspan='3'>", "");
                                sellNormal = sellNormal.Replace("\n", "");
                                sellNormal = sellNormal.Replace("\t", "");
                                sellNormal = sellNormal.Replace(",", "");
                            }

                            // 모든값 폼 3로 넘기기
                            form3.SetInstantData(serverName, itemType, minBuyNum, maxBuyNum, sellUnit, sellNormal);
                        }
                    }  
                }
            }
        }
        private void From2_Closing(object sender, FormClosingEventArgs e)
        {
            // 폼 전환
            this.Hide();
            form1.Show();
        }
    }
}
