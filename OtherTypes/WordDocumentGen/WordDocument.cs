using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Color = System.Drawing.Color;
using Novacode;

namespace WordDocumentGen
{
    /*.png image was removerd because it is 1.7 MB 
     * tha whole homework had to be under 2MB 
     * so you have to use your image from homework.
     */
    class Program
    {
        static void Main()
        {
            using (StreamReader sr = new StreamReader("Content/text.txt", Encoding.UTF8))
            {
                using (DocX doc = DocX.Create("Output.doc"))
                {
                    Paragraph p = doc.InsertParagraph(sr.ReadLine(), false);
                    p.Alignment = Alignment.center;
                    p.FontSize(32);
                    p.Bold();
                    Image img = doc.AddImage("Content/rpg-game.png");
                    Picture pic = img.CreatePicture(300, 600);
                    p.AppendPicture(pic);
                    doc.InsertParagraph(sr.ReadLine());
                    Paragraph p3 = doc.InsertParagraph(sr.ReadLine());
                    Formatting format = new Formatting { Bold = true };
                    p3.ReplaceText("role playing game", "role playing game", false, RegexOptions.None, format);
                    format.UnderlineStyle = UnderlineStyle.singleLine;
                    p3.ReplaceText("grand prize!", "grand prize!", false, RegexOptions.None, format);
                    doc.InsertParagraph(sr.ReadLine());

                    List list = doc.AddList(sr.ReadLine(), 0, ListItemType.Bulleted);
                    doc.AddListItem(list, sr.ReadLine());
                    doc.AddListItem(list, sr.ReadLine());
                    doc.AddListItem(list, sr.ReadLine());
                    list.Items[0].IndentationBefore = 1.5f;
                    list.Items[1].IndentationBefore = 1.5f;
                    list.Items[2].IndentationBefore = 1.5f;
                    doc.InsertList(list);
                    doc.InsertParagraph("");

                    string[] tableHeaders = sr.ReadLine().Split();

                    Table table = doc.AddTable(4, 3);
                    table.Alignment = Alignment.center;
                    table.Design = TableDesign.TableGrid;
                    table.Rows[0].Cells[0].FillColor = Color.CornflowerBlue;
                    table.Rows[0].Cells[0].Paragraphs.First().Append(tableHeaders[0]).Bold().Alignment = Alignment.center;
                    foreach (var cell in table.Rows[0].Cells)
                    {
                        cell.Width = doc.PageWidth / 3;
                        cell.MarginBottom = 0;
                        cell.MarginLeft = 0;
                        cell.MarginRight = 0;
                        cell.MarginTop = 0;
                    }
                    table.Rows[0].Cells[1].FillColor = Color.CornflowerBlue;
                    table.Rows[0].Cells[1].Paragraphs.First().Append(tableHeaders[1]).Bold().Alignment = Alignment.center;
                    table.Rows[0].Cells[2].FillColor = Color.CornflowerBlue;
                    table.Rows[0].Cells[2].Paragraphs.First().Append(tableHeaders[2]).Bold().Alignment = Alignment.center;
                    string[] tableContents = sr.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                        .Concat(sr.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                        .Concat(sr.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
                    int index = 0;
                    for (int i = 1; i < table.RowCount; i++)
                    {
                        for (int j = 0; j < table.ColumnCount; j++)
                        {
                            table.Rows[i].Cells[j].Paragraphs[0].Append(tableContents[index]).Alignment = Alignment.center;
                            index++;
                        }
                    }
                    doc.InsertTable(table);
                    doc.InsertParagraph(sr.ReadLine());

                    Paragraph p4 = doc.InsertParagraph(sr.ReadLine()).Bold().FontSize(12).Color(Color.DarkBlue);
                    p4.ReplaceText("SPECTACULAR", "SPECTACULAR", false, RegexOptions.None, new Formatting { Bold = true, FontColor = Color.DarkBlue, Size = 12 });
                    p4.AppendLine(sr.ReadLine().ToUpper())
                        .Bold()
                        .FontSize(24)
                        .UnderlineStyle(UnderlineStyle.singleLine)
                        .Color(Color.DarkBlue)
                        .UnderlineColor(Color.DarkBlue);
                    p4.Alignment = Alignment.center;

                    doc.Save();
                }
            }
        }
    }
}