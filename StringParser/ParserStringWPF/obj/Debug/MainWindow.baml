   M S B A M L   `   `   `  ����J  FParserStringWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ParserStringWPFParserStringWPF  5   	        ParserStringWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ParserStringWPF     5   	     � Title$  
MainWindow��5   	   $	��550��6   $
��1250��6)    � WindowStartupLocation$ CenterScreen=�66   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��71* �6   �� 5      $	��12* �6   �� 5      $	��71* �6    � RowDefinitions 5   
   �� 5      $	��22* �6   �� 5      $	��28* �6   �� 5      $
��194* �6   �� 5      $	��45* �6   �� 5      $��8* �6   �� 5      $	��46* �6   �� 5      $��8* �6   �� 5      $	��46* �6   �� 5      $��9* �6   �� 5      $	��46* �6   �� 5      $	��76* �6   .+�5   
   �� -   5         ��Name$ 	_1st_list��5      $��1��6%   ��.  ���	#FFFFFCD5$��15(�6o   $��Times New Roman)�6}   $��10��6�   $��2��6�   $��0,27.6,96.4,-0.2q�6�   �� 5   
   -   5        $ 	_2nd_list��5      $��1��6%   ��.  ���	#FFFFFCD5$��15(�6o   $��Times New Roman)�6}   $��10��6�   $��1��6�   $��2��6�   $��96.4,27.6,0.2,-0.2q�6�   o� 5!   
   $��2,0,-1.8,2.4q�6   $��3��6%   .@�5"      m� $
��Menu��6   .@�5#      m� -   5         m�Name$ open_itm��5#      $
��Open��6.   6<   m� 5$      -   5        $ load_itm��5$      $��Load from array��6.   .@�5%      m� -   5        $��Array 1��5%      60   m� 5&      $��Array 2��6   m� 5'      $��Array 3��6   5(      m� 5)      -   5        $ save_itm��5)      $
��Save��6/   6=   �� 5*      m� 5+      -   5        $ 	close_itm��5+      $��Close��60   6?   5,      m� 5-      $��About��6   6(   5.      �� 50   
   -   5         ��Name$ 	list1_lbl��50      $��Select file in Menu��6#   $��Center=�6A   $��1��6e   $��13(�6r   $
��Bold"�6�   �� 51   
   $��Parsed data from txt file��6   $��Center=�64   $��13(�6X   $
��Bold"�6f   $��2��6x   $��1��6�   $��1��6�   �� 52   
   -	   5         ��Name$ 	parse_btb��52      $��Parse��6$   $��1��64   $��7��6E   $
��Bold"�6R   $��Times New Roman)�6d   $��16(�6�   6�   �� 53   
   -
   5        $ 
clear2_btn��53      $��Clear List 2��6%   $��1��6<   $��5��6M   $
��Bold"�6Z   $��Times New Roman)�6l   $��16(�6�   6�   �� 54   
   -   5        $ 
clear1_btn��54      $��Clear List 1��6%   $��1��6<   $��3��6M   $
��Bold"�6Z   $��Times New Roman)�6l   $��16(�6�   6�   �� 55   
   -   5        $ send_mail_btn��55      $��
Send email��6(   $��1��6=   $��9��6N   $
��Bold"�6[   $��Times New Roman)�6m   $��16(�6�   6�   57      58      