using FlatSharp;
using WWEMUS;

namespace MusOTron;

public partial class Form1 : Form
{
    private int currindex;
    private Musi parsed;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Form1()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        InitializeComponent();
    }
    private void Open_Click(object sender, EventArgs e)
    {
        OpenFileDialog of = new()
        {
            Title = "Open MusicList.jsfb",
            Filter = "MusicList.jsfb (*.jsfb)|*.jsfb",
        };
        if (of.ShowDialog() == DialogResult.OK)
        {
            string LSFBName = of.FileName;

            ProcessJSFB(LSFBName);
        }

    }

    private void button2_Click(object sender, EventArgs e)
    {
        SaveFileDialog sf = new()
        {
            Title = "Save MusicList.jsfb",
            Filter = "MusicList.jsfb (*.jsfb)|*.jsfb",
        };
        if (sf.ShowDialog() == DialogResult.OK)
        {
            string saveName = sf.FileName;
            int maxBytesNeeded = Musi.Serializer.GetMaxSize(parsed);
            byte[] buffer = new byte[maxBytesNeeded];
            int bytesWritten = Musi.Serializer.Write(buffer, parsed);

            File.WriteAllBytes(saveName, buffer);
            MessageBox.Show("File saved to " + saveName);
        }

    }

    private void ProcessJSFB(string fileName)
    {
        byte[] buffer = File.ReadAllBytes(fileName);
        parsed = Musi.Serializer.Parse(buffer, FlatBufferDeserializationOption.GreedyMutable); // Can't edit anything otherwise
        if (parsed != null)
        {
            currindex = 1;
            ShowRecord(parsed);
        }
    }

    private void ShowRecord(WWEMUS.Musi parsed)
    {
        numericUpDown1.Value = currindex;
        label17.Text = parsed.Slot.Count.ToString();

        Music record = parsed.Slot[currindex - 1];

        if (record != null)
        {
            textBox3.Text = record.Index.ToString();
            textBox4.Text = record.Name1;
            textBox5.Text = record.Name2;
            textBox7.Text = record.Looppoint.ToString();
            textBox7.Enabled = true;
            textBox1.Text = record.Flags.ToString();
            textBox6.Text = record.Index2a.ToString("X");
            //textBox10.Text = record.Index2b.ToString("X");
            textBox8.Text = record.Hex3.ToString("X");
            textBox9.Text = record.Unlock.ToString();
        }
        else
        {
            throw new NotImplementedException();
        }

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int searchtext = (int)numericUpDown1.Value;

        if (searchtext > 0 && searchtext < parsed.Slot.Count)
        {
            currindex = searchtext;
            ShowRecord(parsed);
        }
        else if (searchtext <= 0)
        {
            currindex = 1;
            ShowRecord(parsed);
        }
        else if (searchtext >= parsed.Slot.Count)
        {
            currindex = parsed.Slot.Count;
            ShowRecord(parsed);
        }


    }

    private void button3_Click(object sender, EventArgs e)
    {
        if (currindex >= 2 && parsed != null)
        {
            currindex -= 1;
            ShowRecord(parsed);
        }
    }

    private void button4_Click(object sender, EventArgs e)
    {
        if (parsed != null && currindex < parsed.Slot.Count)
        {
            currindex += 1;
            ShowRecord(parsed);
        }

    }


    private void button6_Click(object sender, EventArgs e)
    {
        int searchtext = Convert.ToUInt16(textBox14.Text);
        bool found = false;

        for (int i = 0; i < parsed.Slot.Count; i++)
        {
            if (parsed.Slot[i].Index == searchtext)
            {
                currindex = i + 1;
                ShowRecord(parsed);
                break;
            }
        }
        if (found == false)
        {
            MessageBox.Show("Reached end, found nothing");
        }
    }

    private void button5_Click(object sender, EventArgs e)
    {
        String searchtext = textBox2.Text.ToString().ToLower();
        bool found = false;
        for (int i = currindex + 1; i < parsed.Slot.Count; i++)
        {
            if (parsed.Slot[i].Name1.ToString().ToLower().StartsWith(searchtext))
            {
                currindex = i + 1;
                found = true;
                ShowRecord(parsed);
                break;
            }
        }
        if (found == false)
        {
            MessageBox.Show("Reached end, found nothing");
        }
    }

    private void textBox7_TextChanged(object sender, EventArgs e)
    {
        float newcue = float.Parse(textBox7.Text);

        if (parsed.Slot[currindex - 1].Looppoint != newcue)
        {
            parsed.Slot[currindex - 1].Looppoint = newcue;
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        bool found = false;
        for (int i = currindex - 1; i != 0; i--)
        {
            if (parsed.Slot[i].Looppoint != 0)
            {
                currindex = i + 1;
                found = true;
                ShowRecord(parsed);
                break;
            }
        }
        if (found == false)
        {
            MessageBox.Show("Reached end, found nothing");
        }
    }

    private void button7_Click(object sender, EventArgs e)
    {
        bool found = false;
        for (int i = currindex; i < parsed.Slot.Count; i++)
        {
            if (parsed.Slot[i].Looppoint != 0)
            {
                currindex = i + 1;
                found = true;
                ShowRecord(parsed);
                break;
            }
        }
        if (found == false)
        {
            MessageBox.Show("Reached end, found nothing");
        }

    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        Music template = parsed.Slot[currindex - 1];
        Music blank = new Music();
        blank.Index = (uint)parsed.Slot.Count + 1;
        blank.Unk = template.Unk;
        blank.Name1 = "PLACEHOLDER " + blank.Index;
        blank.Name2 = "TRACK NAME " + blank.Index;
        blank.Flags = template.Flags;
        blank.Looppoint = (float)0.0;
        blank.Index2a = template.Index2a;
        //blank.Index2b = template.Index2b;
        blank.Hex3 = template.Hex3;
        blank.Unk8 = template.Unk8;
        blank.Unk9 = template.Unk9;
        blank.Unlock = template.Unlock;

        parsed.Slot.Add(blank);
        label17.Text = parsed.Slot.Count.ToString();

        currindex = parsed.Slot.Count;
        ShowRecord(parsed);

    }

    private void button3_Click_1(object sender, EventArgs e)
    {
        parsed.Slot.RemoveAt(parsed.Slot.Count);
        label17.Text = parsed.Slot.Count.ToString();

        currindex = parsed.Slot.Count - 1;
        ShowRecord(parsed);
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {
        if (parsed.Slot[currindex - 1].Name1 != textBox4.Text)
        {
            parsed.Slot[currindex - 1].Name1 = textBox4.Text;
        }
    }

    private void textBox5_TextChanged(object sender, EventArgs e)
    {
        if (parsed.Slot[currindex - 1].Name2 != textBox5.Text)
        {
            parsed.Slot[currindex - 1].Name2 = textBox5.Text;
        }
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        uint newindex = uint.Parse(textBox3.Text);

        if (parsed.Slot[currindex - 1].Index != newindex)
        {
            parsed.Slot[currindex - 1].Index = newindex;
        }

    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {
        sbyte newindex = sbyte.Parse(textBox1.Text);

        if (parsed.Slot[currindex - 1].Flags != newindex)
        {
            parsed.Slot[currindex - 1].Flags = newindex;
        }

    }

    private void textBox6_TextChanged(object sender, EventArgs e)
    {

        byte newindex = Convert.ToByte(textBox6.Text,16);


        if (parsed.Slot[currindex - 1].Index2a != newindex)
        {
            parsed.Slot[currindex - 1].Index2a = newindex;
        }
    }

    private void textBox10_TextChanged(object sender, EventArgs e)
    {

        //byte newindex = Convert.ToByte(textBox10.Text, 16);


        //if (parsed.Slot[currindex - 1].Index2b != newindex)
        //{
        //    parsed.Slot[currindex - 1].Index2b = newindex;
        //}
    }

    private void textBox8_TextChanged(object sender, EventArgs e)
    {

        uint newindex = Convert.ToUInt32(textBox8.Text, 16);

        if (parsed.Slot[currindex - 1].Hex3 != newindex)
        {
            parsed.Slot[currindex - 1].Hex3 = newindex;
        }

    }

    private void textBox9_TextChanged(object sender, EventArgs e)
    {
        sbyte newindex = sbyte.Parse(textBox9.Text);

        if (parsed.Slot[currindex - 1].Unlock != newindex)
        {
            parsed.Slot[currindex - 1].Unlock = newindex;
        }


    }
}
