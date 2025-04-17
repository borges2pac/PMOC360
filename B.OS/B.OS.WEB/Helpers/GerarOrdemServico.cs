using B.OS.WEB.Models.ViewModels;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using System;
using System.IO;

namespace B.OS.WEB.Helpers
{
	public class GerarOrdemServico
	{
		public static string GerarPdf(GerarPdfViewModel model)
		{
			string retorno = string.Empty;

			try
			{
				var documento = Document.Create(container =>
				{
					container.Page(page =>
					{
						page.Margin(40);
						page.Size(PageSizes.A4);
						page.PageColor(Colors.White);
						page.DefaultTextStyle(x => x.FontSize(12));

						page.Header()
							.Text("Ordem de Serviço")
							.SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

						page.Content().PaddingVertical(10).Column(col =>
						{
							col.Item().Text($"Data: {model.Abertura}");

							col.Item().LineHorizontal(1);

							col.Item().Text("Dados do Cliente:").Bold().FontSize(14);
							col.Item().Text($"Nome: {model.ClienteNome}");
							col.Item().Text($"Documento: {model.Documento}");
							col.Item().Text($"Endereço: {model.Endereco}");
							col.Item().Text($"Telefone: {model.Telefone}");

							col.Item().LineHorizontal(1);

							col.Item().Text("Dados do Equipamento:").Bold().FontSize(14);
							col.Item().Text($"Tipo: {model.Equipamento}");
							col.Item().Text($"Fabricante: {model.Fabricante}");
							col.Item().Text($"Modelo: {model.Modelo}");

							col.Item().LineHorizontal(1);

							col.Item().Text("Problema Relatado:").Bold().FontSize(14);
							col.Item().Text($"{model.Problema}");

							col.Item().LineHorizontal(1);

							col.Item().Text("Observação:").Bold().FontSize(14);
							col.Item().Text($"{model.Observacao}");
						});

						page.Footer()
							.AlignCenter()
							.Text(txt =>
							{
								txt.Span("Obrigado pela preferência!").FontSize(10);
							});
					});
				});

				var caminho = $"D:\\Documentos\\OrdemServico\\{model.ClienteId}_{model.Abertura}_OS.pdf";
				documento.GeneratePdf(caminho);
				retorno = $"PDF gerado com sucesso: {Path.GetFullPath(caminho)}";
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return retorno;
		}
	}
}
