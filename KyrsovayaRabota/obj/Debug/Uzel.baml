   M S B A M L   `   `   `  ����J  FKyrsovayaRabota, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:KyrsovayaRabotaKyrsovayaRabota  5   	       KyrsovayaRabota.Uzel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:KyrsovayaRabota     5   	     � Title$:  4Параметры виртуального узла��5   	   $	��500��6-   $
��1000��6:   .��5	      � $��0,0,0,-6q�6   .+�5
   
   �� $��Код узла��6   $
��Left=�6#   $��26��6>   $��	26,25,0,0q�6J   $	��Top=�6]   $	��106��6u   �� 5   
   $'��!Наименование узла��6   $
��Left=�6,   $��28��6G   $��	26,56,0,0q�6S   $	��Top=�6f   $	��128��6~   �� 5   
   -   5         ��Name$ UzNameTextBox��5      $
��Left=�6)   $��20��6D   $��
194,60,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��237��6�   �� 5   
   -   5        $ CodeUzTextBox��5      $
��Left=�6)   $��22��6D   $��
194,29,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��237��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��97��6T   $��	17,10,0,0q�6`   $	��Top=�6s   $	��445��6�   �� 5   
   -   5         ��Name$ AddSeButton��5      $8��2Добавить сборочную единицу��6&   $
��Left=�6K   $��46��6f   $��
486,10,0,0q�6r   $	��Top=�6�   $	��213��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
SeDataGrid��5      $
��Left=�6'   $	��124��6B   $��295,259,0,0q�6O   $	��Top=�6d   $	��627��6|   $y�Hidden=�6�   "   VerticalScrollBarVisibility$ Disabled=�6�      RowHeaderWidth$ 0Q�6�      
IsReadOnly .    CanUserAddRows .  	   CanUserDeleteRows	 .  ��. 6D  �� 5   
   -   5        
 ��Name$
 SeLabel��5      $'��!Сборочные единицы��6!   $
��Left=�6=   $��38��6X   $��427,221,0,0q�6d   $	��Top=�6y   $	��164��6�   $y�Hidden=�6�   �� 5   
   -   5        $ 
BackButton��5      $+��%Выйти в главное меню��6%   $
��Left=�6D   $��46��6_   $��
712,61,0,0q�6k   $	��Top=�6   $	��214��6�   6�   �� 5   
   -   5        $ ChangeSeButton��5      $8��2Изменить сборочную единицу��6)   $
��Left=�6N   $��46��6i   $��
486,61,0,0q�6u   $	��Top=�6�   $	��213��6�   {�.  6�   �� 5   
   -   5        $ CalculateButton��5      $'��!Произвести расчёт��6*   $
��Left=�6F   $��45��6a   $��486,122,0,0q�6m   $	��Top=�6�   $	��440��6�   6�   �� 5   
   -	   5        $ DeleteSe��5      $6��0Удалить сборочную единицу��6#   $
��Left=�6G   $��46��6b   $��
713,10,0,0q�6n   $	��Top=�6�   $	��213��6�   {�.  6�   5      5      