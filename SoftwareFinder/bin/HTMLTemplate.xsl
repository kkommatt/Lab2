<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/Softwares">
        <html>
        <head>
            <title>Search results:</title>
			<link rel="shortcut icon" href="http://www.iconj.com/ico/t/j/tjfrfeyrty.ico" type="image/x-icon" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0" />

            <style>
                .content-table {
                    border-collapse: collapse;
                    margin: 25px 0;
                    border-spacing: 5px;
                    font-size: 0.9em;
                    min-width: 420px;
                    border-radius: 7px 7px 0 0;
                    overflow: hidden;
                    box-shadow: 0 0 20px rgba(0, 0, 0, 0.17);
                }

                .content-table thead tr {
                    background: #F5AE1C;
                    text-align: left;
                    font-weight: bold;
                }

                .content-table th,
                .content-table td {
                    padding: 12px 15px;
                }

                .content-table tbody tr {
                    border-bottom: 1px solid #DCDCDC;
                }

                .content-table tbody tr:nth-of-type(even) {
                    background-color: #F3F3F3;
                }

                .content-table tbody tr:last-of-type {
                    border-bottom: 2px solid #F5AE1C;
                }

                body {
                    font-family: SF Mono !important;
                    font-size: 28px;
                }
            </style>
        </head>

        <body>
        <h1>Search results:</h1>
        <table class="content-table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Annotation</th>
                    <th>Type</th>
                    <th>Version</th>
                    <th>Developer</th>
                    <th>Distribution</th>
                </tr>
            </thead>
            <xsl:for-each select="Software">
                <tr>
                    <td>
                        <xsl:value-of select="Name" />
                    </td>
                    <td>
                        <xsl:value-of select="Annotation" />
                    </td>
                    <td>
                        <xsl:value-of select="Type" />
                    </td>
                    <td>
                        <xsl:value-of select="Version" />
                    </td>
                    <td>
                        <xsl:value-of select="Developer" />
                    </td>
                    <td>
                        <xsl:value-of select="Distribution" />
                    </td>
                </tr>
            </xsl:for-each>
        </table>
        </body>
        </html>
    </xsl:template>
</xsl:stylesheet>