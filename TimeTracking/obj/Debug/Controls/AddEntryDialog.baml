   M S B A M L   `   `   `  ����  TimeTracking*    $TimeTracking.Controls.AddEntryDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  AddEntryWindwow��5   C    � Title$ Eintrag hinzufügen��6	    � SizeToContent$ WidthAndHeight=�6$    � 
ResizeMode$ NoResize=�6\   .��5      �  � RowDefinitions 5	   
   �� 5
      $��30 �6   �� 5      $��30 �6   �� 5      $	��100 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   6-   �� 5      $	��160 �6   6-   �� 5      $	��130 �6   .+�5   
   �� $��0��6   $��0��6   $��Aktivität:��6-   �� 5   
   $	��150��6   $��22��6   $��0��6+   $��1��68   ��6H   �� *AllActivities+ �� SelectedValue 6n   �� *SelectedValue+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $	��120��6   $��20��6   $��Aktivität hinzufügen��6)   $��0��6H   $��4��6U   ��6e   �� *AddActivityClicked+�� 5   
   $��1��6   $��Dauer:��6   �� 5   
   $��5q�6   $��1��6   $��1��6*   ��6:   �� *
Duration+�� 5   
   $	��100��6   $��2��6   $��0��6)   $��
Kommentar:��69   �� 5   
   $��5q�6   $��2��6   $��1��6*   ��6:   �� *	Comment+�� 5   
   $��50��6   $��20��6   $
��Left=�6(   $��5,0,0,0q�6C   $��OK��6T   $��3��6a   $��1��6n   ��6~   �� *	OkClicked+��6�   �� 	 �� ElementName$	 AddEntryWindwow���� 5   
   $��70��6   $��20��6   $��Right=�6(   $��0,0,5,0q�6D   $��	Abbrechen��6U   $��3��6i   $��1��6v   ��6�   �� *CancelClicked+��6�   �� $	 AddEntryWindwow��5      5      