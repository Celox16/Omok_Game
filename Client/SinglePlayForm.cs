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
    public partial class SinglePlayForm : Form
    {
        private const int rectSize = 33; // 오목판의 셀 크기
        private const int edgeCount = 15; // 오목판의 선 개수 (보통 오목은 15x15의 환경)

        private enum Horse { none = 0, BLACK, WHITE}; // 흰색 말 = 1, 검은 말 = 2, 비어있으면 0으로 설정
        private Horse[,] board = new Horse[edgeCount, edgeCount]; // 15*15형태의 2차원 배열형태를 만들어줌 board의 각 원소는 enum자료형 (흰색, 검은색말)
        private Horse nowPlayer = Horse.BLACK; // 현재 게임을 진행하는 플레이어를 정해줌 (검은돌이 먼저 수행함)
        public SinglePlayForm()
        {
            InitializeComponent();
        }

        private void boardPicture_MouseDown(object sender, MouseEventArgs e) // 오목판을 클릭했을때의 이벤트
        {
            Graphics g = this.boardPicture.CreateGraphics(); // 그림을 그리기위한 객체
            int x = e.X / rectSize; // 현재 사용자가 클릭한 셀의 위치가 어디인지 계산함
            int y = e.Y / rectSize; // 0 ~ 14로 제한하게 됨
            if (x < 0 || y < 0 || x >= edgeCount || y >= edgeCount)
            {
                MessageBox.Show("테두리를 벗어날 수 없습니다.");
                return;
            }
            MessageBox.Show(x + ", " + y); // 현재 클릭한 좌표를 보여줌
            if(nowPlayer == Horse.BLACK) // 만약 사용자가 black이라면
            {
                SolidBrush brush = new SolidBrush(Color.Black); // 현재 오목판의 그래픽 객체에
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize); // 원형을 그리게 됨
                
            }
            else // black이 아니라면
            {
                SolidBrush brush = new SolidBrush(Color.White); // 현재 오목판의 그래픽 객체에
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize); // 원형을 그리게 됨
            }
        }

        private void boardPicture_Paint(object sender, PaintEventArgs e) // 오목판의 그림객체가 그려질때마다 refresh됨
        {
            Graphics gp = e.Graphics;
            Color lineColor = Color.Black; // 오목판의 선 색깔
            Pen p = new Pen(lineColor, 2);
            gp.DrawLine(p, rectSize / 2, rectSize / 2, rectSize / 2, rectSize * edgeCount - rectSize / 2); // 좌측
            gp.DrawLine(p, rectSize / 2, rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize / 2); // 상측
            gp.DrawLine(p, rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize * edgeCount - rectSize / 2); // 하측
            gp.DrawLine(p, rectSize * edgeCount - rectSize / 2, rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize * edgeCount - rectSize / 2); // 우측
            p = new Pen(lineColor, 1);
            // 대각선 방향으로 이동하면서 십자가 모양의 선 그리기
            for(int i = rectSize + rectSize / 2; i < rectSize * edgeCount - rectSize / 2; i += rectSize)
            {
                gp.DrawLine(p, rectSize / 2, i, rectSize * edgeCount - rectSize / 2, i);
                gp.DrawLine(p, i, rectSize / 2, i, rectSize * edgeCount - rectSize / 2);
            }
        }
    }
}
