using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookist.Web.Entities;

public class Book
{
    public int Id { get; set; }

    [DisplayName("����")]
    [Required, MaxLength(100)]
    public string Title { get; set; }

    [DisplayName("����")]
    [Required, MaxLength(255)]
    public string Cover { get; set; }

    [DisplayName("����")]
    [MaxLength(100)]
    public string Author { get; set; }

    [DisplayName("��������")]
    public DateOnly PubDate { get; set; }

    [DisplayName("����")]
    [MaxLength(2000)]
    public string Description { get; set; }

    [DisplayName("�ļ���ʽ")]
    [Required, MaxLength(50)]
    public string Format { get; set; }

    [DisplayName("��ȡ����")]
    [Required, MaxLength(100)]
    public string FetchUrl { get; set; }

    [DisplayName("��ȡ��")]
    [MaxLength(10)]
    public string FetchCode { get; set; }
}