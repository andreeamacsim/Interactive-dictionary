   M S B A M L   `   `   `  ����D  @Tema1_MAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Tema1_MAP	Tema1_MAP  5   	       Tema1_MAP.WordSearchView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Tema1_MAP     5   	     � Title$  WordSearchView��5   	   $	��450��6    $	��800��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� -   5         ��Name$ SearchComboBox��5      $��Center=�6/   $��	0,0,454,0q�6J    �� 
IsEditable .  �� IsTextSearchEnabled .  w� TextPath 6�   Z� 6�   �� 5      -   5        $��Search��5      $��1��6&   $��	10,0,10,0q�66   $��Center=�6I   6d   5      �� 5   
   -   5        $ CategoryComboBox��5      $��0��6-   $��1��6:   $��10q�6J   $��Center=�6V   $	��200��6q   �� 5    
   -   5         ��Name$ WordListBox��5       $��1��6'   $��
10,98,0,44q�64   $
��Left=�6H   $	��300��6d   6p   �� 5#   
   $��1��6   $��	10,3,10,4q�6"    �� Orientation$ Vertical=�65   .+�5$      �� -   5        	 ��Name$	 SelectedWordLabel��5$      $��Selected Word:��6/   $
��Bold"�6H   $��Italic$�6Z   �� 5%      -   5        $	 DescriptionLabel��5%      $��Description:��6.   $
��Bold"�6E   $��Italic$�6W   �� 5&      -   5        $	 CategoryLabel��5&      $��	Category:��6+   $
��Bold"�6?   $��Italic$�6Q   �� 5'      -   5        
 ��Name$
 ImageBox��5'      $	��200��6&   $	��300��63    J� RenderTransformOrigin$ 0.522,0.556&�6?   5(      5)      5*      