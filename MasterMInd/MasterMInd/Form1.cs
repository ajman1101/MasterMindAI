using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


//a, 1, Red
//b, 2, Green
//c, 3, Blue
//d, 4, Yellow
//e, 5, Black
//f, 6, White


namespace MasterMInd
{
    
    public enum GameState
    {
        Single,
        Double,
        AI
    }

    public partial class Form1 : Form
    {
        //every new game
        public string  []guess = new string[4];
        PictureBox[,] shit = new PictureBox[12, 4];
        PictureBox[] things = new PictureBox[4];
        Label[] infoLabels = new Label[12];
        Random rng = new Random();
        const int NUM_SPOTS = 4;
        const int NUM_CLRS = 5;
        string clr = "";
        string []answers = new string[NUM_SPOTS];
        string choice;
        int boxX = 0;
        int boxY= 10;
        int width = 15;
        int height = 15;
        int r = 0;
        int c = 0;
        int count_correct = 0;
        int count_color = 0;
        GameState state = new GameState();
        int i = 0;
        int[] answersInfo = new int[4];
        string[] remColor1 = new string[6];
        string[] remColor2 = new string[6];
        string[] remColor3 = new string[6];
        string[] remColor4 = new string[6];
        string[] tempAnswers = new string[4];

        public Form1()
        {
            InitializeComponent();
        }

            public void CheckGameState()
        {
            switch (state)
            {
                case GameState.AI:
                    ChooseAnswers(i);
                    break;
                case GameState.Double:
                     ChooseAnswers(i);
                     if (i == 4)
                     {
                         MakePegs();
                     }
                    break;
                case GameState.Single:
                    MakeAnswers();
                    MakePegs();
                    break;
            }
        }

            private void button1_Click(object sender, EventArgs e)
            {
                if (state == GameState.Double)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3)
                    {
                        ChangeAnswers(i);
                        i++;
                    }
                    else if (i == 4)
                    {
                        ChooseAnswers(i);
                        for (int j = 0; j < 4; j++)
                        {
                            things[j].BackColor = Color.Transparent;
                            things[j].Visible = false;
                            label1.Text = "Player 2\nStart Guessing!";
                        }
                        MakePegs();
                        i++;
                    }
                    if (i == 5 || i ==6)
                    {
                        i++;
                    }
                    if (i == 7)
                    {
                        ChangePeg();
                    }
                }
                else if (state == GameState.Single)
                {
                    ChangePeg();
                }
                else if (state == GameState.AI)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3)
                    {
                        ChangeAnswers(i);
                        i++;
                    }
                    else if (i == 4)
                    {
                        Point here = new Point(3000, 3000);
                        for (int j = 0; j < 4; j++)
                        {
                            things[j].BackColor = Color.Transparent;
                            things[j].Visible = false;
                            things[j].Location = here;
                            label1.Text = "Here goes the AI!";
                            radioButton1.Visible = false;
                            radioButton2.Visible = false;
                            radioButton3.Visible = false;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;
                            radioButton6.Visible = false;
                            button1.Visible = false;
                        }
                        MakeAIPegs();
                        AI();
                    } 
                }
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            button1.Visible = false;
        }

        private void MakeAIPegs()
        {
            Label guessLabel = new Label();
            Point guessLabelSpot = new Point(10, 20);
            guessLabel.Location = guessLabelSpot;
            guessLabel.Visible = true;
            guessLabel.Text = "Guess";
            int guessX = 50;
            int guessY = 40;
            Point here = new Point(180, 20);
            label1.Location = here;

            boxY = 10;
            for (int h = 0; h < 12; h++)
            {
                Point gSpot = new Point(guessX,guessY);
                guessY += 30;
                boxY += 30;
                boxX = 40;
                Label gLabel = new Label();
                gLabel.Location = gSpot;
                int q = h + 1;
                string num = q.ToString();
                gLabel.Text = num + ":";
                //makes the row and all the info needed for the picture box
                for (int j = 0; j < 4; j++)
                {
                    boxX += 30;
                    PictureBox box = new PictureBox();
                    box.Visible = true;
                    Point spot = new Point(boxX, boxY);
                    box.Location = spot;
                    box.BackColor = Color.Transparent;
                    box.Width = width;
                    box.Height = height;
                    box.BorderStyle = BorderStyle.FixedSingle;
                    box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    shit[h, j] = box;
                    Label guessNum = new Label();
                    Controls.Add(box);
                }
                Controls.Add(gLabel);
            }
            Controls.Add(guessLabel);
        }

        private void MakePegs()
        {
            button1.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = true;
            boxY = 10;
            Control [] collection = new Control[2];
            for (int h = 0; h < 12; h++)
            {
                boxY += 30;
                boxX = 0;
                //makes the row and all the info needed for the picture box
                for (int j = 0; j < 4; j++)
                {
                    boxX += 30;
                    PictureBox box = new PictureBox();
                    box.Visible = true;
                    Point spot = new Point(boxX, boxY);
                    box.Location = spot;
                    box.BackColor = Color.Transparent;
                    box.Width = width;
                    box.Height = height;
                    box.BorderStyle = BorderStyle.FixedSingle;
                    box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    shit[h, j] = box;
                    collection[1] = box;
                    Controls.AddRange(collection);
                    if (j == 3)
                    {
                        Label info = new Label();
                        Point infoSpot= new Point(box.Location.X +20, box.Location.Y);
                        info.Location = infoSpot;
                        infoLabels[h] = info;
                        collection[0]= info;
                        Controls.AddRange(collection);
                    }
                }
            }
        }

        public int  ChooseAnswers(int k)
        {
            Control[] collection = new Control[2];

            if (k == 4)
            {
                Point spot = new Point(3000,3000);
                for (int i =0; i < 4; i++)
                {
                    things[i].Location = spot;           
                }
            }
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = true;
            button1.Visible = true;
                boxY += 30;
                boxX = 0;
                int l =0;
                if (state == GameState.AI)
                {
                    label1.Text = "Input your Guess \nThe AI will then Guess";
                }
                else if (state == GameState.Double)
                {
                    label1.Text = "Player 1 put in your secret code.\nPlayer 2 look away!";
                }
                //makes the row and all the info needed for the picture box
                for (int j = 0; j < 4; j++)
                {
                    boxX += 30;
                    PictureBox box = new PictureBox();
                    box.Visible = true;
                    Point spot = new Point(boxX, boxY);
                    box.Location = spot;
                    box.BackColor = Color.Transparent;
                    box.Width = width;
                    box.Height = height;
                    box.BorderStyle = BorderStyle.FixedSingle;
                    box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    things[j] = box;
                    collection[1] = box;
                     l = j;
                     Controls.AddRange(collection);
                }
                return l;
        }

        //makes the answer colors
        private void MakeAnswers()
          {
            for (int i = 0; i < NUM_SPOTS; i++)
            {
                int num = rng.Next(NUM_CLRS);
                switch (num)
                {
                    case 0:
                        clr = "Red";
                        answers[i] = clr;
                        break;
                    case 1:
                        clr = "Blue";
                        answers[i] = clr;
                        break;
                    case 2:
                        clr = "Yellow";
                        answers[i] = clr;
                        break;
                    case 3:
                        clr = "Green";
                        answers[i] = clr;
                        break;
                case 4:
                        clr = "White";
                        answers[i] = clr;
                        break;
                case 5:
                        clr = "Black";
                        answers[i] = clr;
                        break;
                default:
                        break;
                }
            }
        }

          //method checks through array of answers to see if correct(spot and color)
          //then checks to see if color is in array for each user input
          //meaning that user can get very interesting count_color
          //e.g. correct answer has red once put user puts red twice
          //thus count_color is two 
        public void CheckAnswers()
        {
            int[] answersInfo = new int[4];

            for (int j = 0; j < 4; j++)
            {
                if (answers[j] == guess[j])
                {
                    count_correct++;
                    answersInfo[j] = 1;
                }
                else
                {
                    switch (j)
                    {
                        case 0:
                            remColor1[j] = guess[j];
                            break;
                        case 1:
                            remColor2[j] = guess[j];
                            break;
                        case 2:
                            remColor3[j] = guess[j];
                            break;
                        case 3:
                            remColor4[j] = guess[j];
                            break;
                    }
                }

                if (count_correct == 4)
                {
                    label1.Text = "The AI Found the Right Code!\nYou Lose!";
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;
                    radioButton5.Visible = false;
                    radioButton6.Visible = false;
                    button1.Visible = false;
                }
                else
                {
                    label1.Text = "Correct Spot and Color: " + count_correct + "\nCorrect Color But Not Spot: " + count_color;
                }
            }
        }


        public void CheckAnswers(int collumn, int row)
        {
            if (state == GameState.AI)
            {
                string[] tempAnswers = new string[4];
                int[] answersInfo = new int[4];

                for (int j = 0; j < 3; j++)
                {
                if (answers[collumn] == guess[j])
                {
                    count_correct++;
                    answersInfo[j] = 1;
                }

                if (answers[j] == guess[j])
                {
                    if (tempAnswers[j] == null)
                    {
                        tempAnswers[j] = answers[j];
                        count_color++;
                        answersInfo[j] = 0;
                    }
                }

                if (collumn == 3)
                {
                    label1.Text = "Correct Spot and Color: " + count_correct + "\nCorrect Color But Not Spot: " + count_color;
                }
                    if (count_correct == 4)
                    {
                        label1.Text = "You Found the Right Code!\nYou Win!";
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        radioButton3.Visible = false;
                        radioButton4.Visible = false;
                        radioButton5.Visible = false;
                        radioButton6.Visible = false;
                        button1.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Correct Spot and Color: " + count_correct + "\nCorrect Color But Not Spot: " + count_color;
                    }
            }
            }
            else
            {
                count_color = 0;

                if (answers[collumn] == choice)
                {
                    tempAnswers[collumn] = "C";
                }
                else
                {
                    for (int i = 0; i < answers.Length; i++)
                    {
                        if (answers[i] == choice)
                        {
                            tempAnswers[collumn] = "WS";
                        }
                        else
                        {
                            tempAnswers[collumn] = "W";
                        }
                    }
                }

                if (collumn == 3)
                {
                    infoLabels[row].Width = 1000;
                    infoLabels[row].Text = "Spots: 1 " + tempAnswers[0] + " 2: " + tempAnswers[1] + " 3: " + tempAnswers[2] + " 4: " + tempAnswers[3];
                    infoLabels[row].Visible = true;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (tempAnswers[i] == "C")
                    {
                        if (i == 3)
                        {
                            label1.Text = "You Found the Right Code!\nYou Win!";
                            Point spot = new Point(160, 10);
                            label1.Location = spot;
                            radioButton1.Visible = false;
                            radioButton2.Visible = false;
                            radioButton3.Visible = false;
                            radioButton4.Visible = false;
                            radioButton5.Visible = false;
                            radioButton6.Visible = false;
                            button1.Visible = false;
                        }
                    }
                }
            }
        }

        public void AIRand(string [] notColor, int i)
        {
            int rand = rng.Next(6);
            bool done = false;
            for (int q = 0; q < 6; q++)
            {
                if(guess[i] == notColor[q])
                {
                    while (done == false)
                    {
                        if (AIRand(i) != notColor[q])
                        {
                            done = true;
                        }
                    }
                }
            }
        }

        public string AIRand(int i)
        {
            int rand = rng.Next(6);
            switch (rand)
            {
                case 0:
                    guess[i] = "Red";
                    break;
                case 1:
                    guess[i] = "Green";
                    break;
                case 2:
                    guess[i] = "Blue";
                    break;
                case 3:
                    guess[i] = "Yellow";
                    break;
                case 4:
                    guess[i] = "Black";
                    break;
                case 5:
                    guess[i] = "White";
                    break;
                case 6:
                    AIRand();
                    break;
            }
            return guess[i];
        }

        public void AIRand()
        {
            for (int i = 0; i < 4; i++)
            {
                int rand = rng.Next(6);
                switch (rand)
                {
                    case 0:
                        guess[i] = "Red";
                        break;
                    case 1:
                        guess[i] = "Green";
                        break;
                    case 2:
                        guess[i] = "Blue";
                        break;
                    case 3:
                        guess[i] = "Yellow";
                        break;
                    case 4:
                        guess[i] = "Black";
                        break;
                    case 5:
                        guess[i] = "White";
                        break;
                    case 6:
                        AIRand();
                        break;
                }
            }
        }

          public void ChangePeg()
          {
              //make a picture box 
              PictureBox box = new PictureBox();
              if (r == 11 && c == 3)
              {
                  label1.Text = "You could not figure out\n the code in time!\n You Lose!";
                  box = shit[r, c];
                  switch (choice)
                  {
                      case "Red":
                          box.BackColor = Color.Red;
                          break;
                      case "Blue":
                          box.BackColor = Color.Blue;
                          break;
                      case "Yellow":
                          box.BackColor = Color.Yellow;
                          break;
                      case "Green":
                          box.BackColor = Color.ForestGreen;
                          break;
                      case "White":
                          box.BackColor = Color.WhiteSmoke;
                          break;
                      case "Black":
                          box.BackColor = Color.Black;
                          break;
                  }
                  int x = 0;
                  int y = 400;
                  //make answers apper here
                  for (int i = 0; i < 4; i++)
                  {
                      x += 30;
                      PictureBox answerBox = new PictureBox();
                      answerBox.Height = 10;
                      answerBox.Width = 10;
                      Point area = new Point(x, y);
                      answerBox.Location = area;
                      switch (answers[i])
                      {
                          case "Red":
                              answerBox.BackColor = Color.Red;
                              break;
                          case "Blue":
                              answerBox.BackColor = Color.Blue;
                              break;
                          case "Yellow":
                              answerBox.BackColor = Color.Yellow;
                              break;
                          case "Green":
                              answerBox.BackColor = Color.ForestGreen;
                              break;
                          case "White":
                              answerBox.BackColor = Color.WhiteSmoke;
                              break;
                          case "Black":
                              answerBox.BackColor = Color.Black;
                              break;
                      }
                      Controls.Add(answerBox);
                  }
                  label1.Visible = true;
                  label1.Text = "Here are the correct answers!";
                  Point spot = new Point(10, 430);
                  label1.Location = spot;
              }
              else
              {

              //get user choice and make it a string

              //every 4 collumn, reset the collumn var, add one to row var, reset var for answers
              if (c == 4)
              {
                  c = 0;
                  r++;
                  count_color = 0;
                  count_correct = 0;
                  label1.Visible = false;
              }

              //get picture box to picture box in array at [row, collumn]
              box = shit[r, c];

              //use check answers method with current collumn
              CheckAnswers(c, r);

              //add one to collumn after getting answer
              c++;

              //switch b/w all colors and set the current peg to said color
              switch (choice)
              {
                  case "Red":
                      box.BackColor = Color.Red;
                      break;
                  case "Blue":
                      box.BackColor = Color.Blue;
                      break;
                  case "Yellow":
                      box.BackColor = Color.Yellow;
                      break;
                  case "Green":
                      box.BackColor = Color.ForestGreen;
                      break;
                  case "White":
                      box.BackColor = Color.WhiteSmoke;
                      break;
                  case "Black":
                      box.BackColor = Color.Black;
                      break;
                    }
              }
          }

          private void AI()
          {
              Control[] addBoxes = new Control[4];
              int[] guessColors = new int[6];
              int r = 0;
              int c = 0;

              //makes the array of picutreboxes for the 1st guess randomly

              AIRand();

              for (int b = 0; b < 12; b++)
              {
                  for (int j = 0; j < 4; j++)
                  {
                      PictureBox box = shit[r, j];
                      switch (guess[j])
                      {
                          case "Red":
                              box.BackColor = Color.Red;
                              box.Visible = true;
                              Controls.AddRange(addBoxes);
                              break;
                          case "Blue":
                              box.BackColor = Color.Blue;
                              box.Visible = true;
                              Controls.AddRange(addBoxes);
                              break;
                          case "Yellow":
                              box.BackColor = Color.Yellow;
                              box.Visible = true;
                              Controls.AddRange(addBoxes);
                              break;
                          case "Green":
                              box.BackColor = Color.ForestGreen;
                              box.Visible = true;
                              Controls.AddRange(addBoxes);
                              break;
                          case "White":
                              box.BackColor = Color.WhiteSmoke;
                              box.Visible = true;
                              Controls.AddRange(addBoxes);
                              break;
                          case "Black":
                              box.BackColor = Color.Black;
                              box.Visible = true;
                              Controls.AddRange(addBoxes);
                              break;
                      }
                  }

                  CheckAnswers();
                  c = 0;
                  r++;
                      for (int j = 0; j < 4; j++)
                      {
                          switch (j)
                          {
                              case 0:
                                  AIRand(remColor1, j);
                                  break;
                              case 1:
                                  AIRand(remColor2, j);
                                  break;
                              case 2:
                                  AIRand(remColor3, j);
                                  break;
                              case 3:
                                  AIRand(remColor4, j);
                                  break;
                          }
                      }
                  count_color = 0;
                  count_correct = 0;
              }
          }
        //need to get params of box to change?? or look at process for singleplayer..... too tired to code now
          public int ChangeAnswers(int i)
          {
              PictureBox box=things[i] ;
              //get user choice and make it a string

              //get picture box to picture box in array at [row, collumn]
              answers[i]= choice;

              //switch b/w all colors and set the current peg to said color
              switch (choice)
                      {
                  case "Red":
                      box.BackColor = Color.Red;
                      break;
                  case "Blue":
                      box.BackColor = Color.Blue;
                      break;
                  case "Yellow":
                      box.BackColor = Color.Yellow;
                      break;
                  case "Green":
                      box.BackColor = Color.ForestGreen;
                      break;
                  case "White":
                      box.BackColor = Color.WhiteSmoke;
                      break;
                  case "Black":
                      box.BackColor = Color.Black;
                      break;
                      }
              return i;
          }


        private void Single_Click(object sender, EventArgs e)
        {
            Single.Visible = false;
            Two.Visible = false;
            AIButton.Visible = false;
            state = GameState.Single;
            CheckGameState();
        }

        private void Two_Click(object sender, EventArgs e)
        {
            Single.Visible = false;
            Two.Visible = false;
            AIButton.Visible = false;
            state = GameState.Double;
            CheckGameState();
        }

        private void AIButton_Click(object sender, EventArgs e)
        {
            Single.Visible = false;
            Two.Visible = false;
            AIButton.Visible = false;
            state = GameState.AI;
            CheckGameState();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            choice = "Red";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            choice = "Blue";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            choice = "Green";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            choice = "Black";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            choice = "White";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            choice = "Yellow";
        }
    }
}
