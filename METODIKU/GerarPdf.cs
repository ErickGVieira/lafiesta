using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Fonts;

namespace METODIKU
{
    class GerarPdf
    {
        public void relatorio(int id, int idFesta)
        {
            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                BD_FESTA festa = new BD_FESTA();
                BD_ITENS itens = new BD_ITENS();

                String[] dados = new String[4];
                dados = festa.pegarDadosFesta(id, idFesta);

                var page = doc.AddPage();
                var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
                XBrush titulos = new XSolidBrush(XColor.FromArgb(22, 93, 180));

                var font = new PdfSharp.Drawing.XFont("Comic Sans MS", 20);
                var font2 = new PdfSharp.Drawing.XFont("Verdana", 12);
                
                graphics.DrawRoundedRectangle(PdfSharp.Drawing.XPens.Black, 10, 10, 576, 1050, 10, 10);

                textFormatter.DrawString(dados[0], font, titulos, new PdfSharp.Drawing.XRect(40, 50, page.Width, page.Height));
                graphics.DrawImage(PdfSharp.Drawing.XImage.FromFile(@"\Users\erick\Desktop\Projeto Interdisciplinar 2º Semestre\LAFIESTA\METODIKU\Resources\tiozao.png"), 530, 30, 50, 50);

                textFormatter.DrawString("Local da festa: ", font2, titulos, new PdfSharp.Drawing.XRect(40, 100, 150, 70));
                textFormatter.DrawString(dados[1], font2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(132, 100, 150, 70));
                textFormatter.DrawString("Total de convidados: ", font2, titulos, new PdfSharp.Drawing.XRect(350, 100, 150, 70));
                textFormatter.DrawString(dados[2], font2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(480, 100, 150, 70));

                textFormatter.DrawString("Data da festa: ", font2, titulos, new PdfSharp.Drawing.XRect(40, 120, 150, 70));
                textFormatter.DrawString(dados[3], font2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(132, 120, 250, 70));

                textFormatter.DrawString("Comidas: ", font2, titulos, new PdfSharp.Drawing.XRect(40, 160, 150, 70));

                textFormatter.DrawString("Número", font2, titulos, new PdfSharp.Drawing.XRect(60, 190, 30, 70));
                textFormatter.DrawString("Tipo", font2, titulos, new PdfSharp.Drawing.XRect(150, 190, 100, 70));
                textFormatter.DrawString("Nome", font2, titulos, new PdfSharp.Drawing.XRect(290, 190, 100, 70));
                textFormatter.DrawString("Unidade", font2, titulos, new PdfSharp.Drawing.XRect(460, 190, 100, 70));

                DataTable comidas = new DataTable();
                comidas = itens.comidas(idFesta);
                int y = 220;
                string item = null;
                if (comidas != null)
                {
                    for(int i = 0; i < comidas.Rows.Count; i++)
                    {
                        DataRow dr = comidas.Rows[i];
                        if(dr[1].ToString() == "FINGER FOODS") {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "          " + dr[2].ToString() + "               " + dr[3].ToString();
                        }else if (dr[1].ToString() == "VEGETARIANA")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "           " + dr[2].ToString() + "     " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "DOCE")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                        " + dr[2].ToString() + "                           " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "CHURRASCO")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "             " + dr[2].ToString() + "                         " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "COFFEE BREAK")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "           " + dr[2].ToString() + "                              " + dr[3].ToString();
                        }
                        else
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                        " + dr[2].ToString() + "                              " + dr[3].ToString();
                        }
                        textFormatter.DrawString(item, font2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(80, y, 550, 70));
                        y += 20;
                    }
                }

                textFormatter.DrawString("Bebidas: ", font2, titulos, new PdfSharp.Drawing.XRect(40, y+20, 150, 70));
                y += 40;

                textFormatter.DrawString("Número", font2, titulos, new PdfSharp.Drawing.XRect(60, y, 30, 70));
                textFormatter.DrawString("Tipo", font2, titulos, new PdfSharp.Drawing.XRect(150, y, 100, 70));
                textFormatter.DrawString("Nome", font2, titulos, new PdfSharp.Drawing.XRect(290, y, 100, 70));
                textFormatter.DrawString("Unidade", font2, titulos, new PdfSharp.Drawing.XRect(460, y, 100, 70));

                DataTable bebidas = new DataTable();
                bebidas = itens.bebidas(idFesta);
                if (bebidas != null)
                {
                    y += 30;
                    for (int i = 0; i < bebidas.Rows.Count; i++)
                    {
                        DataRow dr = bebidas.Rows[i];
                        if (dr[1].ToString() == "ALCOOLICAS")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                  " + dr[2].ToString() + "                              " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "REFRIGERANTES")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "            " + dr[2].ToString() + "                                  " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "SUCOS")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                       " + dr[2].ToString() + "                         " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "ÁGUAS")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                  " + dr[2].ToString() + "                             " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "COFFEE BREAK")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                 " + dr[2].ToString() + "                                " + dr[3].ToString();
                        }
                        else
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                       " + dr[2].ToString() + "                             " + dr[3].ToString();
                        }
                        textFormatter.DrawString(item, font2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(80, y, 550, 70));
                        y += 20;
                    }
                }

                textFormatter.DrawString("Utensilios: ", font2, titulos, new PdfSharp.Drawing.XRect(40, y + 20, 150, 70));
                y += 40;

                textFormatter.DrawString("Número", font2, titulos, new PdfSharp.Drawing.XRect(60, y, 30, 70));
                textFormatter.DrawString("Tipo", font2, titulos, new PdfSharp.Drawing.XRect(150, y, 100, 70));
                textFormatter.DrawString("Nome", font2, titulos, new PdfSharp.Drawing.XRect(290, y, 100, 70));
                textFormatter.DrawString("Unidade", font2, titulos, new PdfSharp.Drawing.XRect(460, y, 100, 70));

                DataTable utensilios = new DataTable();
                utensilios = itens.utensilios(idFesta);
                if (utensilios != null)
                {
                    y += 30;
                    for (int i = 0; i < utensilios.Rows.Count; i++)
                    {
                        DataRow dr = utensilios.Rows[i];
                        if (dr[1].ToString() == "COLHERES")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "              " + dr[2].ToString() + "               " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "COPOS")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                  " + dr[2].ToString() + "            " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "MESA")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                         " + dr[2].ToString() + "                       " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "GARFOS")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                  " + dr[2].ToString() + "                " + dr[3].ToString();
                        }
                        else if (dr[1].ToString() == "FACAS")
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "                      " + dr[2].ToString() + "                    " + dr[3].ToString();
                        }
                        else
                        {
                            item = dr[0].ToString() + "          " + dr[1].ToString() + "              " + dr[2].ToString() + "               " + dr[3].ToString();
                        }
                        //else if (dr[1].ToString() == "REFRIGERANTES")
                        //{
                        // item = dr[0].ToString() + "          " + dr[1].ToString() + "            " + dr[2].ToString() + "                                  " + dr[3].ToString();
                        //}
                        //else if (dr[1].ToString() == "SUCOS")
                        //{
                        //   item = dr[0].ToString() + "          " + dr[1].ToString() + "                       " + dr[2].ToString() + "                             " + dr[3].ToString();
                        //}
                        textFormatter.DrawString(item, font2, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(80, y, 550, 70));
                        y += 20;
                    }
                }

                doc.Save(dados[0] + ".pdf");
                System.Diagnostics.Process.Start(dados[0] + ".pdf");
            }
        }
    }
}

