import {BreadcrumbItem, Breadcrumbs, Table, TableBody, TableCell, TableColumn, TableHeader, TableRow} from "@nextui-org/react";
import {Snippet} from "@nextui-org/snippet";

export default function Info1() {
  return (
    <>
      <Breadcrumbs itemClasses={{item: "text-lg"}} underline="hover" className="mb-3" color="primary">
        <BreadcrumbItem href="/quests">Квеcты</BreadcrumbItem>
        <BreadcrumbItem href="/quests/1/info">Базовая форма глагола</BreadcrumbItem>
      </Breadcrumbs>
      <div className="text-lg">
        <section className="text-lg mb-3">
          <div className="flex justify-center font-medium text-4xl mb-6 text-primary">
            Квест 1
          </div>
          <div className="mb-4">
            На первом уроке мы научимся спрягать английские глаголы в трех простых временах: <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">настоящее, будущее и прошедшее.</Snippet>
          </div>
          <div>
            В каждом из времен, разберемся как построить <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">утвердительноe, вопросительное и отрицательное</Snippet> предложение.
          </div>
        </section>
        <section className="text-lg">
          <div className="flex justify-center font-medium text-4xl mb-6 text-primary">
            Настоящее время.
          </div>
          <div className="mb-4">
            <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">Утвердительные предложения</Snippet> образуются также как и в русском языке. Сначала идет местоимение, затем глагол.
          </div>
          <div>
            Если используются местоимения <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">he (он)</Snippet>, <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">she (она)</Snippet> или <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">it (это)</Snippet> то к глаголу добавляется
            окончание <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">-s</Snippet>.
          </div>
          <table className="main">
            <tbody>
            <tr>
              <td>
                <table>
                  <tbody>
                  <tr>
                    <td>Do</td>
                    <td>
                      <div>I</div>
                      <div>you</div>
                      <div>we</div>
                      <div>they</div>
                    </td>
                    <td rowSpan="2"><span>love</span></td>
                  </tr>
                  <tr>
                    <td>Does</td>
                    <td>
                      <div>he</div>
                      <div>she</div>
                    </td>
                  </tr>
                  </tbody>
                </table>
              </td>
              <td className="current">
                <table>
                  <tbody>
                  <tr>
                    <td>
                      <div>I</div>
                      <div>you</div>
                      <div>we</div>
                      <div>they</div>
                    </td>
                    <td><span>love</span></td>
                  </tr>
                  <tr>
                    <td>
                      <div>he</div>
                      <div>she</div>
                    </td>
                    <td>love<span className="red">s</span></td>
                  </tr>
                  </tbody>
                </table>
              </td>
              <td>
                <table>
                  <tbody>
                  <tr>
                    <td>
                      <div>I</div>
                      <div>you</div>
                      <div>we</div>
                      <div>they</div>
                    </td>
                    <td>don’t <span>love</span></td>
                  </tr>
                  <tr>
                    <td>
                      <div>he</div>
                      <div>she</div>
                    </td>
                    <td>doesn’t <span>love</span></td>
                  </tr>
                  </tbody>
                </table>
              </td>
            </tr>
            </tbody>
          </table>
        </section>
      </div>
    </>
  )
}