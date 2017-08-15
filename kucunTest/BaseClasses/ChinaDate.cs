using System.Globalization;
using System.Collections;
using System;

/// <summary>
/// �й�ũ��
/// </summary>
/// ���ߣ�http://www.sufeinet.com
public static class ChinaDate
{
	private static ChineseLunisolarCalendar china = new ChineseLunisolarCalendar();
	private static Hashtable gHoliday = new Hashtable();
	private static Hashtable nHoliday = new Hashtable();
	private static string[] JQ = { "С��", "��", "����", "��ˮ", "����", "����", "����", "����", "����", "С��", "â��", "����", "С��", "����", "����", "����", "��¶", "���", "��¶", "˪��", "����", "Сѩ", "��ѩ", "����" };
	private static int[] JQData = { 0, 21208, 42467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989, 308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758 };
	static ChinaDate()
	{
		//��������
		gHoliday.Add("0101", "Ԫ��");
		gHoliday.Add("0214", "���˽�");
		gHoliday.Add("0305", "�׷���");
		gHoliday.Add("0308", "��Ů��");
		gHoliday.Add("0312", "ֲ����");
		gHoliday.Add("0315", "��Ȩ��");
		gHoliday.Add("0401", "���˽�");
		gHoliday.Add("0501", "�Ͷ���");
		gHoliday.Add("0504", "�����");
		gHoliday.Add("0601", "��ͯ��");
		gHoliday.Add("0701", "������");
		gHoliday.Add("0801", "������");
		gHoliday.Add("0910", "��ʦ��");
		gHoliday.Add("1001", "�����");
		gHoliday.Add("1224", "ƽ��ҹ");
		gHoliday.Add("1225", "ʥ����");

		//ũ������
		nHoliday.Add("0101", "����");
		nHoliday.Add("0115", "Ԫ����");
		nHoliday.Add("0505", "�����");
		nHoliday.Add("0815", "�����");
		nHoliday.Add("0909", "������");
		nHoliday.Add("1208", "���˽�");
	}

	/// <summary>
	/// ��ȡũ��,��������" ũ�� ������ʮ������� Ԫ����/������"
	/// </summary>
	/// <param name="dt"></param>
	/// <returns></returns>
	public static string GetChinaDate(DateTime dt)
	{
		if (dt > china.MaxSupportedDateTime || dt < china.MinSupportedDateTime)
		{
			//���ڷ�Χ��1901 �� 2 �� 19 �� - 2101 �� 1 �� 28 ��
			throw new Exception(string.Format("���ڳ�����Χ��������{0}��{1}֮�䣡", china.MinSupportedDateTime.ToString("yyyy-MM-dd"), china.MaxSupportedDateTime.ToString("yyyy-MM-dd")));
		}
        //string str = string.Format("{0} {1}{2}", GetYear(dt), GetMonth(dt), GetDay(dt));
        string str = string.Format("ũ�� {0}{1}{2}", GetYear(dt), GetMonth(dt), GetDay(dt));
        string strJQ = GetSolarTerm(dt);
		if (strJQ != "")
		{
			str += " (" + strJQ + ")";//��ʮ�Ľ���
		}
		string strHoliday = GetHoliday(dt);
		if (strHoliday != "")
		{
			str += " " + strHoliday;//��������
		}
		string strChinaHoliday = GetChinaHoliday(dt);
		if (strChinaHoliday != "")
		{
			str += " " + strChinaHoliday;//ũ������
		}

		return str;
	}

	/// <summary>
	/// ��ȡũ����ݣ���������"[��]����2017"
	/// </summary>
	/// <param name="dt"></param>
	/// <returns></returns>
	public static string GetYear(DateTime dt)
	{
		int yearIndex = china.GetSexagenaryYear(dt);
		string yearTG = " ���ұ����켺�����ɹ�";
		string yearDZ = " �ӳ���î������δ�����纥";
		string yearSX = " ��ţ������������Ｆ����";
		int year = china.GetYear(dt);
		int yTG = china.GetCelestialStem(yearIndex);
		int yDZ = china.GetTerrestrialBranch(yearIndex);

		//string str = string.Format("[{1}]{2}{3}{0}", year, yearSX[yDZ], yearTG[yTG], yearDZ[yDZ]);
        string str = string.Format("{0}{1}[{2}]��",  yearTG[yTG], yearDZ[yDZ], yearSX[yDZ]);
        return str;
	}

    /// <summary>
    /// ��ȡũ���·ݣ���������"����/��/��/����"
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string GetMonth(DateTime dt)
	{
		int year = china.GetYear(dt);
		int iMonth = china.GetMonth(dt);
		int leapMonth = china.GetLeapMonth(year);
		bool isLeapMonth = iMonth == leapMonth;
		if (leapMonth != 0 && iMonth >= leapMonth)
		{
			iMonth--;
		}

		string szText = "�������������߰˾�ʮ";
		string strMonth = isLeapMonth ? "��" : "";
		if (iMonth <= 10)
		{
			strMonth += szText.Substring(iMonth - 1, 1);
		}
		else if (iMonth == 11)
		{
			//strMonth += "ʮһ";
            strMonth += "��";

        }
        else
		{
			strMonth += "��";
		}
		return strMonth + "��";
	}

    /// <summary>
    /// ��ȡũ�����ڣ���������"��/ʮ/إ/��һ"
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string GetDay(DateTime dt)
	{
		int iDay = china.GetDayOfMonth(dt);
		string szText1 = "��ʮإ��";
		string szText2 = "һ�����������߰˾�ʮ";
		string strDay;
		if (iDay == 20)
		{
			strDay = "��ʮ";
		}
		else if (iDay == 30)
		{
			strDay = "��ʮ";
		}
		else
		{
			strDay = szText1.Substring((iDay - 1) / 10, 1);
			strDay = strDay + szText2.Substring((iDay - 1) % 10, 1);
		}
		return strDay;
	}

	/// <summary>
	/// ��ȡ����
	/// </summary>
	/// <param name="dt"></param>
	/// <returns></returns>
	public static string GetSolarTerm(DateTime dt)
	{
		DateTime dtBase = new DateTime(1900, 1, 6, 2, 5, 0);
		DateTime dtNew;
		double num;
		int y;
		string strReturn = "";

		y = dt.Year;
		for (int i = 1; i <= 24; i++)
		{
			num = 525948.76 * (y - 1900) + JQData[i - 1];
			dtNew = dtBase.AddMinutes(num);
			if (dtNew.DayOfYear == dt.DayOfYear)
			{
				strReturn = JQ[i - 1];
			}
		}

		return strReturn;
	}

	/// <summary>
	/// ��ȡ��������
	/// </summary>
	/// <param name="dt"></param>
	/// <returns></returns>
	public static string GetHoliday(DateTime dt)
	{
		string strReturn = "";
		object g = gHoliday[dt.Month.ToString("00") + dt.Day.ToString("00")];
		if (g != null)
		{
			strReturn = g.ToString();
		}

		return strReturn;
	}

	/// <summary>
	/// ��ȡũ������
	/// </summary>
	/// <param name="dt"></param>
	/// <returns></returns>
	public static string GetChinaHoliday(DateTime dt)
	{
		string strReturn = "";
		int year = china.GetYear(dt);
		int iMonth = china.GetMonth(dt);
		int leapMonth = china.GetLeapMonth(year);
		int iDay = china.GetDayOfMonth(dt);
		if (china.GetDayOfYear(dt) == china.GetDaysInYear(year))
		{
			strReturn = "��Ϧ";
		}
		else if (leapMonth != iMonth)
		{
			if (leapMonth != 0 && iMonth >= leapMonth)
			{
				iMonth--;
			}
			object n = nHoliday[iMonth.ToString("00") + iDay.ToString("00")];
			if (n != null)
			{
				if (strReturn == "")
				{
					strReturn = n.ToString();
				}
				else
				{
					strReturn += " " + n.ToString();
				}
			}
		}

		return strReturn;
	}
}
