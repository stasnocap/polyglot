import {BreadcrumbItem, Breadcrumbs} from "@nextui-org/react";
import {Snippet} from "@nextui-org/snippet";

export default function Info1() {
  return (
    <>
      <Breadcrumbs itemClasses={{item: "text-lg"}} underline="hover" className="mb-3" color="primary">
        <BreadcrumbItem href="/quests">Квеcты</BreadcrumbItem>
        <BreadcrumbItem href="/quests/1/info">Квест 1: Базовая форма глагола</BreadcrumbItem>
      </Breadcrumbs>
      <article className="text-lg">
        <div className="mb-2">
          🎯 <b className="text-primary">Миссия</b>: Ты станешь мастером времени, осваивая настоящее, будущее и прошедшее время английских глаголов. Собирай очки опыта за каждое выполненное задание и поднимай свой уровень знаний! 🚀
        </div>
        <section>
          <div className="flex justify-center mb-3 text-2xl font-medium text-primary">
            💡 Шаг 1: Настоящее время
          </div>
          <ul className="mb-2">
            <li className="mb-1">
              🟢 <b className="text-primary">Утвердительные предложения:</b> Начнем с простого. Используй местоимение <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">(я, ты, он, она, оно)</Snippet> и добавь глагол. Если это <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">he, she или it,</Snippet> к
              глаголу добавь окончание <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">-s.</Snippet> Например, <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">"He walks"</Snippet> <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">(Он ходит).</Snippet>
              <table className="m-auto mb-6 mt-6">
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
            </li>
            <li className="mb-1">
              ❌ <b className="text-primary">Отрицательные предложения:</b> Для отрицания используй вспомогательный глагол <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">do</Snippet> и частицу <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">not.</Snippet> Для <Snippet hideCopyButton hideSymbol
                                                                                                                                                                                                                                                                                                                                 className="bg-primary-50 text-primary">he,
              she, it</Snippet> используй does вместо <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">do.</Snippet> Например, <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">"She does not (doesn't) walk"</Snippet> <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">(Она не
              ходит).</Snippet>
              <table className="m-auto mb-6 mt-6">
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
                        <td><span>love</span></td>
                      </tr>
                      <tr>
                        <td>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td>loves</td>
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
                        <td><span className="red">don’t</span> <span>love</span></td>
                      </tr>
                      <tr>
                        <td>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span className="red">doesn’t</span> <span>love</span></td>
                      </tr>
                      </tbody>
                    </table>
                  </td>
                </tr>
                </tbody>
              </table>
            </li>
            <li className="mb-1">
              ❓ <b className="text-primary">Вопросительные предложения:</b> Для вопросов вспомогательный глагол <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">do (или does для he, she, it)</Snippet> ставится в начало. Например, <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">"Do you
              walk?"</Snippet> <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">(Ты ходишь?).</Snippet>
              <table className="m-auto mb-6 mt-6">
                <tbody>
                <tr>
                  <td className="current">
                    <table>
                      <tbody>
                      <tr>
                        <td><span className="red">Do</span></td>
                        <td>
                          <div>I</div>
                          <div>you</div>
                          <div>we</div>
                          <div>they</div>
                        </td>
                        <td rowSpan="2"><span>love</span></td>
                      </tr>
                      <tr>
                        <td><span className="red">Does</span></td>
                        <td>
                          <div>he</div>
                          <div>she</div>
                        </td>
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
                        <td><span>love</span></td>
                      </tr>
                      <tr>
                        <td>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td>loves</td>
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
            </li>
          </ul>
        </section>
        <section>
          <div className="flex justify-center mb-3 text-2xl font-medium text-primary">
            💡 Шаг 2: Прошедшее время
          </div>
          <ul className="mb-2">
            <li className="mb-1">
              🟢 <b className="text-primary">Утвердительные предложения:</b> Используй вторую форму глагола (правильные глаголы получают окончание <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">-ed</Snippet>). Например, <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">"They walked"</Snippet>
              <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">(Они ходили).</Snippet>
              <table className="m-auto mb-6 mt-6">
                <tbody>
                <tr>
                  <td>
                    <table>
                      <tbody>
                      <tr>
                        <td>Did</td>
                        <td>
                          <div>I</div>
                          <div>you</div>
                          <div>we</div>
                          <div>they</div>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>lov<span className="red">ed</span></span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td>did not <span>love</span></td>
                      </tr>
                      </tbody>
                    </table>
                  </td>
                </tr>
                </tbody>
              </table>
            </li>
            <li className="mb-1">
              ❌ <b className="text-primary">Отрицательные предложения:</b> Для отрицания используй глагол <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">did</Snippet> и частицу <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">not (didn’t).</Snippet> Например, <Snippet hideCopyButton hideSymbol
                                                                                                                                                                                                                                                                                                                                 className="bg-primary-50 text-primary">"He
              did not (didn’t) walk"</Snippet> <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">(Он
              не ходил).</Snippet>
              <table className="m-auto mb-6 mt-6">
                <tbody>
                <tr>
                  <td>
                    <table>
                      <tbody>
                      <tr>
                        <td>Did</td>
                        <td>
                          <div>I</div>
                          <div>you</div>
                          <div>we</div>
                          <div>they</div>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>loved</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span className="red">did not</span> <span>love</span></td>
                      </tr>
                      </tbody>
                    </table>
                  </td>
                </tr>
                </tbody>
              </table>
            </li>
            <li className="mb-1">
              ❓ <b className="text-primary">Вопросительные предложения:</b> Для вопросов используй глагол <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">did</Snippet> в начале. Например, <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">"Did you walk?"</Snippet> <Snippet hideCopyButton hideSymbol
                                                                                                                                                                                                                                                                                                                                   className="bg-primary-50 text-primary">(Ты
              ходил?).</Snippet>
              <table className="m-auto mb-6 mt-6">
                <tbody>
                <tr>
                  <td className="current">
                    <table>
                      <tbody>
                      <tr>
                        <td><span className="red">Did</span></td>
                        <td>
                          <div>I</div>
                          <div>you</div>
                          <div>we</div>
                          <div>they</div>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>loved</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td>did not <span>love</span></td>
                      </tr>
                      </tbody>
                    </table>
                  </td>
                </tr>
                </tbody>
              </table>
            </li>
          </ul>
        </section>
        <section>
          <div className="flex justify-center mb-3 text-2xl font-medium text-primary">
            💡 Шаг 3: Будущее время
          </div>
          <ul className="mb-2">
            <li className="mb-1">
              🟢 <b className="text-primary">Утвердительные предложения:</b> Используй глагол <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">will.</Snippet> Например, <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">"We will walk"</Snippet> <Snippet hideCopyButton hideSymbol
                                                                                                                                                                                                                                                                                                             className="bg-primary-50 text-primary">(Мы будем
              ходить).</Snippet>
              <table className="m-auto mb-6 mt-6">
                <tbody>
                <tr>
                  <td>
                    <table>
                      <tbody>
                      <tr>
                        <td>Will</td>
                        <td>
                          <div>I</div>
                          <div>you</div>
                          <div>we</div>
                          <div>they</div>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span className="red">will</span> <span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td>will not <span>love</span></td>
                      </tr>
                      </tbody>
                    </table>
                  </td>
                </tr>
                </tbody>
              </table>
            </li>
            <li className="mb-1">
              ❌ <b className="text-primary">Отрицательные предложения:</b> Для отрицания используй <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">will</Snippet> и частицу <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">not (won’t).</Snippet> Например, <Snippet hideCopyButton hideSymbol
                                                                                                                                                                                                                                                                                                                          className="bg-primary-50 text-primary">"She
              will not (won’t) walk"</Snippet> <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">(Она не
              будет ходить).</Snippet>
              <table className="m-auto mb-6 mt-6">
                <tbody>
                <tr>
                  <td>
                    <table>
                      <tbody>
                      <tr>
                        <td>Will</td>
                        <td>
                          <div>I</div>
                          <div>you</div>
                          <div>we</div>
                          <div>they</div>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td>will <span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span className="red">will not</span> <span>love</span></td>
                      </tr>
                      </tbody>
                    </table>
                  </td>
                </tr>
                </tbody>
              </table>
            </li>
            <li className="mb-1">
              ❓ <b className="text-primary">Вопросительные предложения:</b> Для вопросов ставь глагол <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">will</Snippet> в начало. Например, <Snippet hideCopyButton hideSymbol className="bg-primary-50 text-primary">"Will they walk?"</Snippet> <Snippet hideCopyButton hideSymbol
                                                                                                                                                                                                                                                                                                                                  className="bg-primary-50 text-primary">(Они
              будут ходить?).</Snippet>
              <table className="m-auto mb-6 mt-6">
                <tbody>
                <tr>
                  <td className="current">
                    <table>
                      <tbody>
                      <tr>
                        <td><span className="red">Will</span></td>
                        <td>
                          <div>I</div>
                          <div>you</div>
                          <div>we</div>
                          <div>they</div>
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td><span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td>will <span>love</span></td>
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
                          <div>he</div>
                          <div>she</div>
                        </td>
                        <td>will not <span>love</span></td>
                      </tr>
                      </tbody>
                    </table>
                  </td>
                </tr>
                </tbody>
              </table>
            </li>
          </ul>
        </section>
      </article>
    </>
  )
}