#include <iostream>
#include <windows.h>
#include <cstdlib>
#include <ctime>
#include <cstdio>
#include <fstream>
#include <string>

using namespace std;

string Table [10001] [8];
fstream Results;
fstream EmailsList;
fstream file;
fstream file2;
fstream file3;
HWND Handle;
HANDLE clip0;
HWND hwnd;
HGLOBAL hg;
string ClipboardContent;
string WindowsTitle;
string DataString;
size_t WindowCheckResult;
size_t UrlCheckResult;
size_t EmailCheckResult;
char* p;
char wnd_title[256];
int SearchResult;
int Attempts = 0;

void CollectData (int x, int y, int i, int j)
{
        error1:
        SetCursorPos (30,250);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 30, 250, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 30, 250, 0, 0);
        SetCursorPos (x,y);
        mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        Sleep (100);
        keybd_event( VK_CONTROL, 0, 0, 0 );
        keybd_event( 0x43, 0, 0, 0 );
        keybd_event( 0x43, 0, KEYEVENTF_KEYUP, 0 );
        keybd_event( VK_CONTROL, 0, KEYEVENTF_KEYUP, 0 );
        Sleep (100);
        OpenClipboard(NULL);
        clip0 = GetClipboardData(CF_TEXT);
        p=(char*)GlobalLock(clip0);
        GlobalUnlock(clip0);
        CloseClipboard();
        if (p==NULL) goto error1;
        else ClipboardContent = string(p);
        Table[i][j] = ClipboardContent;
}
    int main()
{
//////////////////////////////////////////////////////////////////////Searching//////////////////////////////////////////////////////////////////////////////////////////
        EmailsList.open("EmailsList.txt");
        for (int i = 1; i<=10000; i++)
        {
        getline (EmailsList, Table[i][1]);
        }
        EmailsList.close();
        Sleep (10000);
        for (int i=1; i<=10000; i++)
        {
        OpenClipboard(0);
        EmptyClipboard();
        hg=GlobalAlloc(GMEM_MOVEABLE,Table[i][1].size());
        memcpy(GlobalLock(hg),Table[i][1].c_str(),Table[i][1].size());
        GlobalUnlock(hg);
        SetClipboardData(CF_TEXT,hg);
        CloseClipboard();
        GlobalFree(hg);

        SetCursorPos (750,215);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 750, 215, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 750, 215, 0, 0);
        keybd_event( VK_CONTROL, 0, 0, 0 );
        keybd_event( 0x41, 0, 0, 0 );
        keybd_event( 0x41, 0, KEYEVENTF_KEYUP, 0 );
        keybd_event( VK_CONTROL, 0, KEYEVENTF_KEYUP, 0 );
        keybd_event( VK_DELETE, 0, 0, 0 );
        keybd_event( VK_DELETE, 0, KEYEVENTF_KEYUP, 0 );
        keybd_event( VK_CONTROL, 0, 0, 0 );
        keybd_event( 0x56, 0, 0, 0 );
        keybd_event( 0x56, 0, KEYEVENTF_KEYUP, 0 );
        keybd_event( VK_CONTROL, 0, KEYEVENTF_KEYUP, 0 );
        keybd_event( VK_RETURN, 0, 0, 0 );
        keybd_event( VK_RETURN, 0, KEYEVENTF_KEYUP, 0 );
        Sleep (3000);
/////////////////////////////////////////////////////////////////////CheckingSearchResult////////////////////////////////////////////////////////////////////////////////
        error2:
        SetCursorPos (380,250);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 380, 250, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 380, 250, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 380, 250, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 380, 250, 0, 0);
        Sleep (100);
        keybd_event( VK_CONTROL, 0, 0, 0 );
        keybd_event( 0x43, 0, 0, 0 );
        keybd_event( 0x43, 0, KEYEVENTF_KEYUP, 0 );
        keybd_event( VK_CONTROL, 0, KEYEVENTF_KEYUP, 0 );
        Sleep (100);
        OpenClipboard(NULL);
        clip0 = GetClipboardData(CF_TEXT);
        p=(char*)GlobalLock(clip0);
        GlobalUnlock(clip0);
        CloseClipboard();
        if (p==NULL) goto error2;
        else ClipboardContent = string(p);
        if (ClipboardContent=="their ") SearchResult = 2;
        else
        {
        SearchResult = 1;
        Table[i][7] = "No";
        }

        if (SearchResult==1)
        {
        error3:
        SetCursorPos (600,365);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 600, 365, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 600, 365, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 600, 365, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 600, 365, 0, 0);
        Sleep (100);
        keybd_event( VK_CONTROL, 0, 0, 0 );
        keybd_event( 0x43, 0, 0, 0 );
        keybd_event( 0x43, 0, KEYEVENTF_KEYUP, 0 );
        keybd_event( VK_CONTROL, 0, KEYEVENTF_KEYUP, 0 );
        Sleep (100);
        OpenClipboard(NULL);
        clip0 = GetClipboardData(CF_TEXT);
        p=(char*)GlobalLock(clip0);
        GlobalUnlock(clip0);
        CloseClipboard();
        if (p==NULL) goto error3;
        else ClipboardContent = string(p);
        if (ClipboardContent=="17")
        {
        Table[i][7] = "Yes";
        }
        }
 //////////////////////////////////////////////////////////////////////Collecting Data////////////////////////////////////////////////////////////////////////////////////
        if (SearchResult==1)
        {
        CollectData(625,270, i, 2);
        Table[i][2] = Table[i][2].substr(1, Table[i][2].length() - 2);

        error4:
        SetCursorPos (30,250);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 30, 250, 0, 0);
        mouse_event(MOUSEEVENTF_LEFTUP, 30, 250, 0, 0);
        SetCursorPos (303,273);
        mouse_event(MOUSEEVENTF_RIGHTDOWN, 303, 273, 0, 0);
        mouse_event(MOUSEEVENTF_RIGHTUP, 303, 273, 0, 0);
        Sleep (100);
        keybd_event( 0x4B, 0, 0, 0 );
        keybd_event( 0x4B, 0, KEYEVENTF_KEYUP, 0 );
        Sleep (100);
        OpenClipboard(NULL);
        clip0 = GetClipboardData(CF_TEXT);
        p=(char*)GlobalLock(clip0);
        GlobalUnlock(clip0);
        CloseClipboard();
        if (p==NULL) goto error4;
        else ClipboardContent = string(p);
        UrlCheckResult = ClipboardContent.find("https");
        if (UrlCheckResult == std::string::npos && Attempts<=3)
        {
        Attempts++;
        Sleep (1000);
        goto error4;
        }
        if (Attempts>3)
        {
        Attempts = 0;
        goto error5;
        }

        Table[i][3] = ClipboardContent;

        CollectData(625,325, i, 4);
        CollectData(625,300, i, 5);
        CollectData(625,290, i, 6);
        Table[i][6] = Table[i][6].substr(1, Table[i][6].length() - 2);
        }

        if (SearchResult==2)
        {
        error5:
        Table[i][2] = "None";
        Table[i][3] = " " ;
        Table[i][4] = " " ;
        Table[i][5] = " " ;
        Table[i][6] = " " ;
        Table[i][7] = " " ;
        }
        if (i%50==0)
        {
        Results.open("Results.txt", ios::app);
        for (int k=i-49; k<=i; k++)
        {
        DataString = Table[k][1]+ Table[k][2] + "|" + Table[k][3] + "|" + Table[k][4] + "|" + Table[k][5] + "|" + Table[k][6] + "|" + Table[k][7] + "\n";
        Results<< DataString;
        }
        Results.close();
        }
        }
        return 0;
}

