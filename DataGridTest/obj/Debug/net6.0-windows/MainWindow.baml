   M S B A M L   `   `   `  ????G  CDataGridTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DataGridTestDataGridTest  5   	       DataGridTest.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:DataGridTest     5   	     ? Title$  
Trafoliste??5   	   $	??450??6   $	??800??6)   $	??450??65   $	??800??6E   $	??450??6T   $	??800??6d   .??5	      ? .+?5
   
   ?? -   5        $??L1??5
      $??Trafos??6   $??Center=?6+   $	??Top=?6H   $??24(?6`   $??Lucida Calligraphy)?6n   $
??Bold"?6?   $??Normal$?6?   ???	#FFB9A9006?   &   System.Windows.Controls.DataGrid  5   
   -   5        $??dataGrid??5         AutoGenerateColumns$ False??6$      CanUserAddRows$ False??6@   $??Center=?5      $	??Top=?62      RowBackground
 ?????$
??Bold"?5   1   ???#525252$
??True??5      $	??360??6:   $	??340??6G      AlternatingRowBackground ?#f2f2f2???#000$??1q?5   K   $
??Auto=?5      $
??Auto=?5      $??0,50,0,0q?6E   .@?6X   />   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6%      Header$ Seriennummer??61      
IsReadOnly$
 True??6o   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6G   ?? 
 ?? Path$
 Seriennummer?6o     5      $	 200 6%   $ Standort??61   $
 True??6p   	 6C   ?? $
 aktuellerStandort?6p     5      $	 200 6%   $ Im-Lager??61   $
 True??6f   	 6C   ?? $
 imLager?6f   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 View??6)      CellTemplate 5      ?? 5      .R?5      ?? $??btnView??6%   -   5        $
??View??5   4   ???	#FFEEEF426Y   5      5        5      $ Update??6)    5      ?? 5      .R?5       ?? $??	btnUpdate??6%   -   5        $??Update??5    6   ???	#FFEEEF426_   5!      5#        5$      $ History??6)    5%      ?? 5&      .R?5'      ?? $??btnAddHistory??6%   -   5        $??
AddHistory??5'   :   ???	#FFEEEF426k   5(      5*      5,      ?? 5-   
   -   5        $??btnNeu??5-      $	??NEW??6   $
??Left=?6-   $??20??6H   $??	20,10,0,0q?6i   $	??Top=?6|   $??50??6?   ???	#FFEEEF42 ? 	Resources 5.       ?? 
TargetType ?? Property ?? Value??%^   '??       ?? 5/      " ??6   .?50      ??  ?@??CornerRadius$ 8??65   51      52      53      ?? 54   
   -   5        $??Refresh??54      $
??Left=?68   $??
100,10,0,0q?6S   $	??Top=?6g   $??20??6   $??50??6?   ???	#FFEEEF42$??Normal"?6?    55      ??%^   '??       ?? 56      " ??6   .?57      ??  ?@??CornerRadius$ 8??65   58      59      5:      ?? 5;   
   -   5         ??Name$ btn_EXIT??5;      $
??EXIT??6:   $??Right=?6I   $??	0,10,20,0q?6e   $	??Top=?6x   ???	#FFEEEF42$??50??6?   $??20??6?    5<      ??%^   '??       ?? 5=      " ??6   .?5>      ??  ?@??CornerRadius$ 8??65   5?      5@      5A      ?? 5B   
   -	   5        $??Write to CSV??5B      $
??Left=?6:   $??
180,10,0,0q?6U   $	??Top=?6i   $??20??6?   $??80??6?   ???	#FFEEEF42$??Normal"?6?    5C      ??%^   '??       ?? 5D      " ??6   .?5E      ??  ?@??CornerRadius$ 8??65   5F      5G      5H      ?? 5I   
   $??0,0,0,0q?6    J? Opacity$ .5Q?6"   $??KS.Productions??6/   $
??Left=?6H   $??20,0,0,5q?6c   $??Bottom=?6u   $??8(?6?   
???   ?$??Vladimir Script)?6?   5K      5L      