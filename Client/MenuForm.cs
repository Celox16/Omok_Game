using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void siglePlayButton_Click(object sender, EventArgs e)
        {
            Hide(); // 현재의 창을 숨김
            SinglePlayForm singlePlayForm = new SinglePlayForm(); // 싱글 플레이 객체 인스턴스 생성
            singlePlayForm.FormClosed += new FormClosedEventHandler(childForm_Closed); // 다시 메뉴폼 화면을 보여주도록 함
            singlePlayForm.Show(); // 새로운창이 눈에 보이도록 함
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); // exit버튼을 누르면 모든 시스템이 종료되도록 windows exit함수 호출
        }

        void childForm_Closed(object sender, FormClosedEventArgs e) // 싱글플레이 창이 닫히고 다시 메뉴화면으로 돌아올 때
        {
            Show();
        }
    }
}
