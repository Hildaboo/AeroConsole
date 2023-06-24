#include <windows.h>

#include <stdio.h>
#include <stdlib.h>

DWORD MakeTransparent(BYTE percent);

int main()
{
	SetConsoleTitleW(L"AeroConsole Demo");
	
	DWORD tpr_res = MakeTransparent(191);
	if(tpr_res)
	{
		wprintf(L"MakeTransparent somehow failed, 0x%08X\r\n", tpr_res);
		return 1;
	}
	
	wprintf(L"Ready\r\n");
	Sleep(1000);
	wprintf(L"Steady\r\n");
	Sleep(1000);
	wprintf(L"GO!\r\n\r\n");
	
	system("pause");
	
	return 0;
}

// idea from LockBit 2.0, however this is not reversed :P
DWORD MakeTransparent(BYTE percent)
{
	HWND console_hwnd = GetConsoleWindow();
	LONG new_long = GetWindowLongW(console_hwnd, GWL_EXSTYLE) ^ WS_EX_LAYERED;
	
	if(!SetWindowLongW(console_hwnd, GWL_EXSTYLE, new_long))
	{
		return GetLastError();
	}
    
	if(!SetLayeredWindowAttributes(console_hwnd, 0, percent, LWA_ALPHA))
	{
		return GetLastError();
	}
	
	return ERROR_SUCCESS;
}
