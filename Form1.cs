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
        //uint newcue = uint.Parse(textBox7.Text);

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

}
