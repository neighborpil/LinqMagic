using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace HelloLinq
{
  // WPFサンプル:PowerPointで作成した図形をWPFで表示する
  //    http://gushwell.ldblog.jp/archives/52317471.html
  // パス マークアップ構文
  //    https://msdn.microsoft.com/ja-jp/library/ms752293%28v=vs.110%29.aspx
  // Graphics.DrawBeziers メソッド 
  //    https://msdn.microsoft.com/ja-jp/library/bs29b5k0.aspx


  public partial class Form1 : Form
  {
    // ベジエ曲線のデータ
    List<PointF[]> BezierPoints = new List<PointF[]>()
    {
      // "H"
      new PointF[] {
        new PointF(3.8056f,5.0588f),                              // 開始点
        new PointF(3.0325f,8.9961f), new PointF(3.1565f,12.832f), // 制御点1,2
        new PointF(3.1567f,16.927f), },                           // 終了点
                                                                  // ここまでで1本のベジエ曲線
      new PointF[] {
        new PointF(9.3564f,4.2675f),
        new PointF(8.6114f,4.9082f), new PointF(9.1444f,10.107f),
        new PointF(9.0162f,14.204f), },
      new PointF[] {
        new PointF(1.7249f,10.917f),
        new PointF(1.8088f,10.002f), new PointF(4.9722f,8.948f),
        new PointF(11.22f,8.011f), },
      // "e"
      new PointF[] {
        new PointF(13.826f,11.847f),
        new PointF(14.789f,11.554f), new PointF(19.963f,10.132f),
        new PointF(19.916f,8.416f),
        new PointF(19.925f,7.4266f), new PointF(17.72f,7.829f),
        new PointF(16.492f,8.433f),
        new PointF(7.9433f,12.406f), new PointF(14.483f,18.399f),
        new PointF(20.417f,11.774f), },
      // "l"
      new PointF[] {
        new PointF(22.631f,2.1096f),
        new PointF(22.549f,6.4196f), new PointF(22.905f,11.279f),
        new PointF(22.905f,15.374f), },
      // "l"
      new PointF[] {
        new PointF(26.889f,2.0352f),
        new PointF(26.807f,6.3452f), new PointF(27.163f,11.205f),
        new PointF(27.163f,15.3f), },
      // "o"
      new PointF[] {
        new PointF(33.186f,8.7254f),
        new PointF(38.198f,5.6181f), new PointF(39.811f,8.777f),
        new PointF(36.802f,12.102f),
        new PointF(31.515f,17.643f), new PointF(27.863f,13.584f),
        new PointF(33.186f,8.7254f), },
      // ","
      new PointF[] {
        new PointF(41.519f,12.567f),
        new PointF(43.485f,11.576f), new PointF(44.479f,13.727f),
        new PointF(40.65f,16.734f), },
      // "L"
      new PointF[] {
        new PointF(54.897f,4.1654f),
        new PointF(55.085f,5.133f), new PointF(54.834f,12.743f),
        new PointF(54.695f,14.529f),
        new PointF(54.057f,13.968f), new PointF(56.412f,15.71f),
        new PointF(62.144f,12.213f), },
      // "I"
      new PointF[] {
        new PointF(64.444f,3.444f),
        new PointF(64.02f,7.7605f), new PointF(63.888f,9.1602f),
        new PointF(64.257f,14.79f), },
      // "N"
      new PointF[] {
        new PointF(69.251f,4.1703f),
        new PointF(69.169f,8.4383f), new PointF(68.766f,11.512f),
        new PointF(69.178f,14.701f), },
      new PointF[] {
        new PointF(68.683f,3.2324f),
        new PointF(71.477f,8.0487f), new PointF(75.023f,11.654f),
        new PointF(76.009f,8.4972f), },
      new PointF[] {
        new PointF(76.462f,2.7969f),
        new PointF(75.971f,8.2269f), new PointF(75.454f,12.117f),
        new PointF(75.893f,14.363f), },
      // "Q"
      new PointF[] {
        new PointF(85.468f,5.4951f),
        new PointF(90.871f,2.6805f), new PointF(92.515f,5.1968f),
        new PointF(88.108f,9.3595f),
        new PointF(78.135f,18.621f), new PointF(74.822f,9.4202f),
        new PointF(88.515f,3.5158f), },
      new PointF[] {
        new PointF(84.727f,10.401f),
        new PointF(86.375f,13.269f), new PointF(88.039f,14.637f),
        new PointF(89.273f,15.799f), },
      // "!"
      new PointF[] {
        new PointF(95.139f,2.7273f),
        new PointF(94.843f,6.9986f), new PointF(94.821f,7.3694f),
        new PointF(94.506f,10.57f), },
      new PointF[] {
        new PointF(94.308f,12.294f),
        new PointF(93.598f,12.792f), new PointF(93.498f,13.879f),
        new PointF(94.779f,13.188f),
        new PointF(95.444f,12.773f), new PointF(95.481f,11.645f),
        new PointF(94.394f,12.291f), },
    };


    public Form1()
    {
      InitializeComponent();

      // ウィンドウのタイトル
      this.Text = "Hello, world!";

      // 描画をダブルバッファリングする指定
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      // Graphicsの既存の状態を保存
      System.Drawing.Drawing2D.GraphicsState state = e.Graphics.Save();

      // アンチエイリアシングと移動・拡大を設定
      e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
      e.Graphics.TranslateTransform(10.0f, 90.0f);
      e.Graphics.ScaleTransform(2.75f, 3.5f);

      // 描画に使う「Pen」を生成
      Pen pen = new Pen(Color.Blue, 1.5f);

      //// すべてのベジエ曲線を描画
      //// 従来の書き方(その1)
      //{
      //  Pen pen3 = new Pen(Color.LightGray, 5.0f);
      //  for (int i = 0; i < BezierPoints.Count; i++)
      //  {
      //    e.Graphics.DrawBeziers(pen3, BezierPoints[i]);
      //  }
      //}

      //// すべてのベジエ曲線を描画
      //// 従来の書き方(その2)
      //{
      //  Pen pen2 = new Pen(Color.DarkRed, 3.0f);
      //  foreach(var points in BezierPoints)
      //  {
      //    e.Graphics.DrawBeziers(pen2, points);
      //  }
      //}

      // 【LINQマジック!】すべてのベジエ曲線を描画
      //BezierPoints.ForEach(points => e.Graphics.DrawBeziers(borderPen, points));
      BezierPoints.ForEach(points => e.Graphics.DrawBeziers(pen, points));

      // Graphicsの状態を復元
      e.Graphics.Restore(state);
    }
  }
}
