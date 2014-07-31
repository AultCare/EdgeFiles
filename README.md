EdgeFiles
=========
<p>
CMS has announced the XML file layouts for Health Insurance Marketplace Edge Server. This C# project will take the raw enrollment, pharmacy claims, and medical claims data and generate output in the Edge Server format. The participation into this project is open to all issuers who are in need of these XML files. Development is being done under the GNU General Public License.
</p>


High Level Overview
=========
<p>This is how we foresee this project working, although it is subject to change. Other ideas/input is, of course, welcome.</p>
<ol>
  <li>Issuers will import their raw data via the EdgeFiles API (included in this solution)</li>
  <li>The EdgeFiles Core project will take the data received via the API and generate the necessary XML files for upload to the EDGE server.</li>
  <li>The output files can be picked up from an output folder, or we can possibly make calls to the AWS S3 API and automatically drop the files in the appropriate bucket (for issuers using AWS).</li>
</ol>
